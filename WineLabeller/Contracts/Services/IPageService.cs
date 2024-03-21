﻿using System.Windows.Controls;

namespace WineLabeller.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
