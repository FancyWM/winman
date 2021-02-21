# WinMan

<img src="https://raw.githubusercontent.com/veselink1/winman/master/Resources/Icon.png" alt="WinMan.UI Logo" style="max-width: 256px;" height="auto">

<img src="https://raw.githubusercontent.com/veselink1/winman/master/Screenshots/demo.gif" alt="WinMan.UI Demo" style="max-width: 100%;" height="auto">

This repository contains several things:

- WinMan - a WIP window management library for .NET with the following features
    * Platform-agnostic design
    * Event-based API
    * Limited compexity thanks to focused features set (currently only app windows supported)
    * Designed to be used by window management software

- WinMan.UI - a window manager for Windows based on WinMan and WPF
    * Aims to be simple
    * Minimal configuration - extensive custom keybindings functionality will not be implemented
    * Can create layouts using keyboard shortcuts - vertical/horizontal split, stacks (like in i3wm) to be added
    * Shortcuts to switch virtual desktops (go to desktop N; go to previous)
    * Might add a task view alternative similar to the one found in KDE Plasma (one that shows all virtual desktops)

- WinMan.Layouts - the cross-platform layout algorithms used by WinMan.UI
    * A tree-based layout data structure
    * Several static window arragement algorithms
