﻿using System;
using System.Windows;
using Grabacr07.KanColleViewer.Views;
using MetroRadiance.Controls;

namespace LvChartPlugin
{
    /* 
     * ViewModelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedWeakEventListenerや
     * CollectionChangedWeakEventListenerを使うと便利です。独自イベントの場合はLivetWeakEventListenerが使用できます。
     * クローズ時などに、LivetCompositeDisposableに格納した各種イベントリスナをDisposeする事でイベントハンドラの開放が容易に行えます。
     *
     * WeakEventListenerなので明示的に開放せずともメモリリークは起こしませんが、できる限り明示的に開放するようにしましょう。
     */

    /// <summary>
    /// ChartWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ChartWindow : MetroWindow
    {
        public ChartWindow()
        {
            this.InitializeComponent();
            WeakEventManager<MainWindow, EventArgs>.AddHandler(
                MainWindow.Current,
                "Closed",
                (_, __) => this.Close());
        }
    }
}