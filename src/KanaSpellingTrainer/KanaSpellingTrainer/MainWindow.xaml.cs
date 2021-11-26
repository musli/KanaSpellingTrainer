using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KanaSpellingTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> ping = new List<string>() {
            "あ","い", "う", "え", "お",
            "か", "き", "く", "け", "こ",
            "さ", "し", "す", "せ", "そ",
            "た", "ち", "つ", "て", "と",
            "な", "に", "ぬ", "ね", "の",
            "は", "ひ", "ふ", "へ", "ほ",
            "ま", "み", "む", "め", "も",
            "や", "ゆ", "よ",
            "ら", "り", "る", "れ", "ろ",
            "わ", "を" };
        List<string> pian = new List<string>() {
            "ア","イ", "ウ", "エ", "オ",
            "カ", "キ", "ク", "ケ", "コ",
            "サ", "シ", "ス", "セ", "ソ",
            "タ", "チ", "ツ", "テ", "ト",
            "ナ", "ニ", "ヌ", "ネ", "ノ",
            "ハ", "ヒ", "フ", "ヘ", "ホ",
            "マ", "ミ", "ム", "メ", "モ",
            "ヤ", "ユ", "ヨ",
            "ラ", "リ", "ル", "レ", "ロ",
            "ワ", "ヲ" };
        List<string> zhuo = new List<string>() {
            "が","ぎ", "ぐ", "げ", "ご",
            "ざ", "じ", "ず", "ず", "ぞ",
            "だ", "ぢ", "づ", "で", "ど",
            "ば", "び", "ぶ", "べ", "ぼ" };
        List<string> zhuopian = new List<string>() {
            "ガ","ギ", "グ", "ゲ", "ゴ",
            "ザ", "ジ", "ズ", "ゼ", "ゾ",
            "ダ", "ヂ", "ヅ", "デ", "ド",
            "バ", "ビ", "ブ", "ベ", "ボ" };
        List<string> banzhuo = new List<string>() {
            "ぱ","ぴ", "ぷ", "ぺ", "ぽ" };
        List<string> banzhuopian = new List<string>() {
            "パ","ピ", "プ", "ペ", "ポ" };
        List<string> ao = new List<string>() {
            "きゃ","きゅ", "きょ",
            "しゃ","しゅ", "しょ",
            "ちゃ","ちゅ", "ちょ",
            "にゃ","にゅ", "にょ",
            "ひゃ","ひゅ", "ひょ",
            "みゃ","みゅ", "みょ",
            "りゃ","りゅ", "りょ",
            "ぎゃ","ぎゅ", "ぎょ",
            "じゃ","じゅ", "じょ",
            "ちゃ","ちゅ", "ちょ",
            "びゃ","びゅ", "びょ",
            "ぴゃ","ぴゅ", "ぴょ" };
        List<string> aoPian = new List<string>() {
            "キャ","キュ", "キョ",
            "シャ","シュ", "ショ",
            "チャ","チュ", "チョ",
            "ニャ","ニュ", "ニョ",
            "ヒャ","ヒュ", "ヒョ",
            "ミャ","ミュ", "ミョ",
            "リャ","リュ", "リョ",
            "キャ","キュ", "キョ",
            "ジャ","ジュ", "ジョ",
            "チュ","チュ", "チョ",
            "ビャ","ビュ", "ビョ",
            "ピャ","ピュ", "ピョ" };
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            refresh();
        }

        private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(500);
                Dispatcher.Invoke(() =>
                {
                    if (txtLabel.Text.Equals(txtContent.Text))
                    {
                        refresh();
                    }
                });
            });
        }
        private void refresh()
        {
            var tempList = new List<string>();
            if (chePing.IsChecked.Value == true)
                tempList.AddRange(ping);
            if (chePian.IsChecked.Value == true)
                tempList.AddRange(pian);
            if (cheZhuoPing.IsChecked.Value == true)
                tempList.AddRange(zhuo);
            if (cheZhuoPian.IsChecked.Value == true)
                tempList.AddRange(zhuopian);
            if (cheBanZhuoPing.IsChecked.Value == true)
                tempList.AddRange(banzhuo);
            if (cheBanZhuoPian.IsChecked.Value == true)
                tempList.AddRange(banzhuopian);
            if (cheAoPing.IsChecked.Value == true)
                tempList.AddRange(ao);
            if (cheAoPian.IsChecked.Value == true)
                tempList.AddRange(aoPian);

            if (tempList.Count > 0)
            {
                var tempStr = new StringBuilder();
                for (int i = 0; i < 20; i++)
                {
                    tempStr.Append(tempList[random.Next(0, tempList.Count)]);
                }
                txtLabel.Text = tempStr.ToString();
                txtContent.Text = string.Empty;
                tempList.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
