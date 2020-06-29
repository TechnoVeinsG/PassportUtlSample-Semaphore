///
/// ADR300 ユーティリティーからデータを取得するサンプル
///     - 平文ファイル -
/// 
/// Copyright (c) 2020 Techno Veins Co.,Ltd.
/// 
/// This software is released under the MIT License.
/// http://opensource.org/licenses/mit-license.php
///

/// 
/// セマフォファイルおよびデータファイルのディレクトリ階層は
/// 以下のようになっていることを想定しています
/// 
/// ベースフォルダ ┳ MRZ   ┳ YYYY-MM-DD ┳ HH-mm-SS-Identifying.tsv
/// 　　　　　　　 ┃       ┃                   :
/// 　　　　　　　 ┃              :
/// 　　　　　　　 ┃
/// 　　　　　　　 ┣ Color ┳ YYYY-MM-DD ┳ HH-mm-SS-Identifying.jpg
/// 　　　　　　　 ┃       ┃                   :
/// 　　　　　　　 ┃              :
/// 　　　　　　　 ┃   :
/// 　　　　　　　 ┃
/// 　　　　　　　 ┗ セマフォファイル
/// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaphore
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 各共有データが格納されているベースフォルダ
        /// </summary>
        /// <remarks>
        /// ADR300 ユーティリティーの設定画面で指定したベースフォルダ名を必要なだけ宣言します
        ///  ※ 設定画面で指定したベースフォルダ名と一致している必要があります
        /// </remarks>
        private const string MRZ_SubDir = @"MRZ";
        private const string Color_SubDir = @"Color";

        /// <summary>
        /// 各共有データの拡張子
        /// </summary>
        /// <remarks>
        /// ADR300 ユーティリティーの設定画面で指定した拡張子と一致している必要があります
        /// </remarks>
        private const string MRZ_Extension = @".tsv";
        private const string Color_Extension = @".jpg";

        /// <summary>
        /// セマフォファイルの格納されているフォルダ
        /// </summary>
        private string m_strBaseDir = string.Empty;

        /// <summary>
        /// セマフォファイルの変更を監視するオブジェクト
        /// </summary>
        private FileSystemWatcher m_Watcher = null;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// セマフォファイルの参照ボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSemaphoreFileFind_Click(object sender, EventArgs e)
        {
            // OpenFileDialog オブジェクト作成
            OpenFileDialog ofd = new OpenFileDialog();
            // ファイル名の初期値を指定する
            ofd.FileName = "semaphore.ctl";
            // 選択肢を指定する
            ofd.Filter = "セマフォファイル(*.ctl)|*.ctl";
            //タイトルを設定する
            ofd.Title = "セマフォファイルを選択してください";
            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            // 存在しないファイル名が指定されたとき警告を表示しない
            ofd.CheckFileExists = false;
            // 存在しないパスが指定されたとき警告を表示する
            ofd.CheckPathExists = true;
            // ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // 選択されたセマフォファイル名を保管
                textBoxSemaphoreFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// セマフォファイル名が変更されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSemaphoreFile_TextChanged(object sender, EventArgs e)
        {
            // 監視を一旦停止
            StopWatcher();
            // 各データが保管されているベースフォルダを取得
            m_strBaseDir = Path.GetDirectoryName(((TextBox)sender).Text);
            // 新しいセマフォファイルを監視
            StartWatcher(((TextBox)sender).Text);
        }

        /// <summary>
        /// ファイルの変更の監視を開始する処理
        /// </summary>
        /// <param name="strPath">監視するファイルのパス</param>
        private void StartWatcher(string strPath)
        {
            // 監視オブジェクトを作成
            m_Watcher = new FileSystemWatcher();
            // 監視するファイルを指定
            m_Watcher.Path = Path.GetDirectoryName(strPath);
            // 最終更新日時の変更を監視する
            m_Watcher.NotifyFilter = (
                NotifyFilters.LastWrite
            );
            // 目的のファイルを監視
            m_Watcher.Filter = Path.GetFileName(strPath);
            // UIのスレッドにマーシャリングする
            // コンソールアプリケーションでの使用では必要ない
            m_Watcher.SynchronizingObject = this;

            // イベントハンドラの追加
            m_Watcher.Changed += new FileSystemEventHandler(WatcherChanged);

            // 監視を開始する
            m_Watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// ファイルの変更の監視を停止する処理
        /// </summary>
        private void StopWatcher()
        {
            if (m_Watcher == null)
            {
                return;
            }
            // 監視を停止する
            m_Watcher.EnableRaisingEvents = false;
            // オブジェクトを開放する
            m_Watcher.Dispose();
            m_Watcher = null;
        }

        /// <summary>
        /// 監視しているファイルが変更されたときのイベント
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void WatcherChanged(Object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    // セマフォファイルから作成されたデータを取得
                    //      "YYYY-MM-DD HH:mm:SS xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" 形式のデータが返されます
                    //       0123456789012345678901234567890123456789012345678901
                    //                 1         2         3         4         5
                    string strLine = string.Empty;
                    using (FileStream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        List<string> strLines = new List<string>();
                        while (!sr.EndOfStream)
                        {
                            strLines.Add(sr.ReadLine());
                        }
                        strLine = strLines.Last();
                    }

                    // ADR300 ユーティリティーの設定画面で指定したデータファイルに合わせて日時を抽出します
                    // 以下の例では、"YYYY-MM-DD\HH-mm-SS-Identifying.○○○" です

                    // 日付を抽出してサブフォルダ名とする
                    //      "YYYY-MM-DD" の部分
                    string strSubDirName = strLine.Substring(0, 10);

                    // 時刻を抽出してプレフィックスとする
                    //      "HH:mm:SS" の部分を抽出して
                    //      "HH-mm-SS" に変換
                    string strPrefixName = strLine.Substring(11, 8).Replace(':', '-');

                    // パスポート番号をベース名とする
                    //      "Identifying" の部分
                    string strBaseName = strLine.Substring(20);

                    // MRZ 取り込み
                    try
                    {
                        // MRZデータのファイル名を生成する
                        //      フォルフダ、拡張子など、実際の環境に合わせてください
                        string strPath = m_strBaseDir + @"\" + MRZ_SubDir + @"\" + strSubDirName + @"\" + strPrefixName + @"-" + strBaseName + MRZ_Extension;
                        // 排他制御を指定してオープンする
                        // ファイルを作成したときのエンコードは Shift-JIS のため、エンコードを指定して StreamReader を開く
                        using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using(StreamReader sr = new StreamReader(fs,Encoding.GetEncoding("Shift_JIS")))
                        {
                            // 読み込んで、TextBoxに表示
                            textBoxMRZ.Text = sr.ReadToEnd();
                        }
                    }
                    catch (Exception)
                    {
                        textBoxMRZ.Text = string.Empty;
                    }

                    // 可視光画像取り込み
                    try
                    {
                        pictureBoxColor.Image = null;

                        // 可視光画像データのファイル名を生成する
                        //      フォルフダ、拡張子など、実際の環境に合わせてください
                        string strPath = m_strBaseDir + @"\" + Color_SubDir + @"\" + strSubDirName + @"\" + strPrefixName + @"-" + strBaseName + Color_Extension;
                        // 排他制御を指定してオープンする
                        using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            // 読み込んで表示
                            pictureBoxColor.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception)
                    {
                        pictureBoxColor.Image = null;
                    }

                    break;
            }
        }
    }
}
