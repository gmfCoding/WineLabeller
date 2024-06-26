﻿using System.Windows.Controls;

namespace WineLabeller.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();
}
