﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardToMouse.Win
{
    //public enum VKeys : uint
    //{
    //    KEY_0 = 0x30, //0 key 
    //    KEY_1 = 0x31, //1 key 
    //    KEY_2 = 0x32, //2 key 
    //    KEY_3 = 0x33, //3 key 
    //    KEY_4 = 0x34, //4 key 
    //    KEY_5 = 0x35, //5 key 
    //    KEY_6 = 0x36, //6 key 
    //    KEY_7 = 0x37, //7 key 
    //    KEY_8 = 0x38, //8 key 
    //    KEY_9 = 0x39, //9 key
    //    KEY_MINUS = 0xBD, // - key
    //    KEY_PLUS = 0xBB, // + key
    //    KEY_A = 0x41, //A key 
    //    KEY_B = 0x42, //B key 
    //    KEY_C = 0x43, //C key 
    //    KEY_D = 0x44, //D key 
    //    KEY_E = 0x45, //E key 
    //    KEY_F = 0x46, //F key 
    //    KEY_G = 0x47, //G key 
    //    KEY_H = 0x48, //H key 
    //    KEY_I = 0x49, //I key 
    //    KEY_J = 0x4A, //J key 
    //    KEY_K = 0x4B, //K key 
    //    KEY_L = 0x4C, //L key 
    //    KEY_M = 0x4D, //M key 
    //    KEY_N = 0x4E, //N key 
    //    KEY_O = 0x4F, //O key 
    //    KEY_P = 0x50, //P key 
    //    KEY_Q = 0x51, //Q key 
    //    KEY_R = 0x52, //R key 
    //    KEY_S = 0x53, //S key 
    //    KEY_T = 0x54, //T key 
    //    KEY_U = 0x55, //U key 
    //    KEY_V = 0x56, //V key 
    //    KEY_W = 0x57, //W key 
    //    KEY_X = 0x58, //X key 
    //    KEY_Y = 0x59, //Y key 
    //    KEY_Z = 0x5A, //Z key 
    //    KEY_LBUTTON = 0x01, //Left mouse button 
    //    KEY_RBUTTON = 0x02, //Right mouse button 
    //    KEY_CANCEL = 0x03, //Control-break processing 
    //    KEY_MBUTTON = 0x04, //Middle mouse button (three-button mouse) 
    //    KEY_BACK = 0x08, //BACKSPACE key 
    //    KEY_TAB = 0x09, //TAB key 
    //    KEY_CLEAR = 0x0C, //CLEAR key 
    //    KEY_RETURN = 0x0D, //ENTER key 
    //    KEY_SHIFT = 0x10, //SHIFT key 
    //    KEY_CONTROL = 0x11, //CTRL key 
    //    KEY_MENU = 0x12, //ALT key 
    //    KEY_PAUSE = 0x13, //PAUSE key 
    //    KEY_CAPITAL = 0x14, //CAPS LOCK key 
    //    KEY_ESCAPE = 0x1B, //ESC key 
    //    KEY_SPACE = 0x20, //SPACEBAR 
    //    KEY_PRIOR = 0x21, //PAGE UP key 
    //    KEY_NEXT = 0x22, //PAGE DOWN key 
    //    KEY_END = 0x23, //END key 
    //    KEY_HOME = 0x24, //HOME key 
    //    KEY_LEFT = 0x25, //LEFT ARROW key 
    //    KEY_UP = 0x26, //UP ARROW key 
    //    KEY_RIGHT = 0x27, //RIGHT ARROW key 
    //    KEY_DOWN = 0x28, //DOWN ARROW key 
    //    KEY_SELECT = 0x29, //SELECT key 
    //    KEY_PRINT = 0x2A, //PRINT key 
    //    KEY_EXECUTE = 0x2B, //EXECUTE key 
    //    KEY_SNAPSHOT = 0x2C, //PRINT SCREEN key 
    //    KEY_INSERT = 0x2D, //INS key 
    //    KEY_DELETE = 0x2E, //DEL key 
    //    KEY_HELP = 0x2F, //HELP key 
    //    KEY_NUMPAD0 = 0x60, //Numeric keypad 0 key 
    //    KEY_NUMPAD1 = 0x61, //Numeric keypad 1 key 
    //    KEY_NUMPAD2 = 0x62, //Numeric keypad 2 key 
    //    KEY_NUMPAD3 = 0x63, //Numeric keypad 3 key 
    //    KEY_NUMPAD4 = 0x64, //Numeric keypad 4 key 
    //    KEY_NUMPAD5 = 0x65, //Numeric keypad 5 key 
    //    KEY_NUMPAD6 = 0x66, //Numeric keypad 6 key 
    //    KEY_NUMPAD7 = 0x67, //Numeric keypad 7 key 
    //    KEY_NUMPAD8 = 0x68, //Numeric keypad 8 key 
    //    KEY_NUMPAD9 = 0x69, //Numeric keypad 9 key 
    //    KEY_SEPARATOR = 0x6C, //Separator key 
    //    KEY_SUBTRACT = 0x6D, //Subtract key 
    //    KEY_DECIMAL = 0x6E, //Decimal key 
    //    KEY_DIVIDE = 0x6F, //Divide key 
    //    KEY_F1 = 0x70, //F1 key 
    //    KEY_F2 = 0x71, //F2 key 
    //    KEY_F3 = 0x72, //F3 key 
    //    KEY_F4 = 0x73, //F4 key 
    //    KEY_F5 = 0x74, //F5 key 
    //    KEY_F6 = 0x75, //F6 key 
    //    KEY_F7 = 0x76, //F7 key 
    //    KEY_F8 = 0x77, //F8 key 
    //    KEY_F9 = 0x78, //F9 key 
    //    KEY_F10 = 0x79, //F10 key 
    //    KEY_F11 = 0x7A, //F11 key 
    //    KEY_F12 = 0x7B, //F12 key 
    //    KEY_SCROLL = 0x91, //SCROLL LOCK key 
    //    KEY_LSHIFT = 0xA0, //Left SHIFT key 
    //    KEY_RSHIFT = 0xA1, //Right SHIFT key 
    //    KEY_LCONTROL = 0xA2, //Left CONTROL key 
    //    KEY_RCONTROL = 0xA3, //Right CONTROL key 
    //    KEY_LMENU = 0xA4, //Left MENU key 
    //    KEY_RMENU = 0xA5, //Right MENU key 
    //    KEY_COMMA = 0xBC, //, key
    //    KEY_PERIOD = 0xBE, //. key
    //    KEY_PLAY = 0xFA, //Play key 
    //    KEY_ZOOM = 0xFB, //Zoom key 
    //    KEY_SEMICOLON = 0xBA,
    //    KEY_QUESTION = 0xBF,
    //    KEY_TILDE = 0xC0,
    //    KEY_OPEN_BRACKET = 0xDB,
    //    KEY_CLOSE_BRACKET = 0xDD,
    //    KEY_QUOTES = 0xDE,
    //    KEY_BACKSLASH = 0xE2,
    //    KEY_PIPE = 0xDC,
    //    NULL = 0x0,
    //}
    public enum WindowsMessages : uint
    {
        WM_NULL = 0x00,
        WM_CREATE = 0x01,
        WM_DESTROY = 0x02,
        WM_MOVE = 0x03,
        WM_SIZE = 0x05,
        WM_ACTIVATE = 0x06,
        WM_SETFOCUS = 0x07,
        WM_KILLFOCUS = 0x08,
        WM_ENABLE = 0x0A,
        WM_SETREDRAW = 0x0B,
        WM_SETTEXT = 0x0C,
        WM_GETTEXT = 0x0D,
        WM_GETTEXTLENGTH = 0x0E,
        WM_PAINT = 0x0F,
        WM_CLOSE = 0x10,
        WM_QUERYENDSESSION = 0x11,
        WM_QUIT = 0x12,
        WM_QUERYOPEN = 0x13,
        WM_ERASEBKGND = 0x14,
        WM_SYSCOLORCHANGE = 0x15,
        WM_ENDSESSION = 0x16,
        WM_SYSTEMERROR = 0x17,
        WM_SHOWWINDOW = 0x18,
        WM_CTLCOLOR = 0x19,
        WM_WININICHANGE = 0x1A,
        WM_SETTINGCHANGE = 0x1A,
        WM_DEVMODECHANGE = 0x1B,
        WM_ACTIVATEAPP = 0x1C,
        WM_FONTCHANGE = 0x1D,
        WM_TIMECHANGE = 0x1E,
        WM_CANCELMODE = 0x1F,
        WM_SETCURSOR = 0x20,
        WM_MOUSEACTIVATE = 0x21,
        WM_CHILDACTIVATE = 0x22,
        WM_QUEUESYNC = 0x23,
        WM_GETMINMAXINFO = 0x24,
        WM_PAINTICON = 0x26,
        WM_ICONERASEBKGND = 0x27,
        WM_NEXTDLGCTL = 0x28,
        WM_SPOOLERSTATUS = 0x2A,
        WM_DRAWITEM = 0x2B,
        WM_MEASUREITEM = 0x2C,
        WM_DELETEITEM = 0x2D,
        WM_VKEYTOITEM = 0x2E,
        WM_CHARTOITEM = 0x2F,

        WM_SETFONT = 0x30,
        WM_GETFONT = 0x31,
        WM_SETHOTKEY = 0x32,
        WM_GETHOTKEY = 0x33,
        WM_QUERYDRAGICON = 0x37,
        WM_COMPAREITEM = 0x39,
        WM_COMPACTING = 0x41,
        WM_WINDOWPOSCHANGING = 0x46,
        WM_WINDOWPOSCHANGED = 0x47,
        WM_POWER = 0x48,
        WM_COPYDATA = 0x4A,
        WM_CANCELJOURNAL = 0x4B,
        WM_NOTIFY = 0x4E,
        WM_INPUTLANGCHANGEREQUEST = 0x50,
        WM_INPUTLANGCHANGE = 0x51,
        WM_TCARD = 0x52,
        WM_HELP = 0x53,
        WM_USERCHANGED = 0x54,
        WM_NOTIFYFORMAT = 0x55,
        WM_CONTEXTMENU = 0x7B,
        WM_STYLECHANGING = 0x7C,
        WM_STYLECHANGED = 0x7D,
        WM_DISPLAYCHANGE = 0x7E,
        WM_GETICON = 0x7F,
        WM_SETICON = 0x80,

        WM_NCCREATE = 0x81,
        WM_NCDESTROY = 0x82,
        WM_NCCALCSIZE = 0x83,
        WM_NCHITTEST = 0x84,
        WM_NCPAINT = 0x85,
        WM_NCACTIVATE = 0x86,
        WM_GETDLGCODE = 0x87,
        WM_NCMOUSEMOVE = 0xA0,
        WM_NCLBUTTONDOWN = 0xA1,
        WM_NCLBUTTONUP = 0xA2,
        WM_NCLBUTTONDBLCLK = 0xA3,
        WM_NCRBUTTONDOWN = 0xA4,
        WM_NCRBUTTONUP = 0xA5,
        WM_NCRBUTTONDBLCLK = 0xA6,
        WM_NCMBUTTONDOWN = 0xA7,
        WM_NCMBUTTONUP = 0xA8,
        WM_NCMBUTTONDBLCLK = 0xA9,

        WM_INPUT = 0x00FF,

        WM_KEYFIRST = 0x100,
        WM_KEYDOWN = 0x100,
        WM_KEYUP = 0x101,
        WM_CHAR = 0x102,
        WM_DEADCHAR = 0x103,
        WM_SYSKEYDOWN = 0x104,
        WM_SYSKEYUP = 0x105,
        WM_SYSCHAR = 0x106,
        WM_SYSDEADCHAR = 0x107,
        WM_KEYLAST = 0x108,

        WM_IME_STARTCOMPOSITION = 0x10D,
        WM_IME_ENDCOMPOSITION = 0x10E,
        WM_IME_COMPOSITION = 0x10F,
        WM_IME_KEYLAST = 0x10F,

        WM_INITDIALOG = 0x110,
        WM_COMMAND = 0x111,
        WM_SYSCOMMAND = 0x112,
        WM_TIMER = 0x113,
        WM_HSCROLL = 0x114,
        WM_VSCROLL = 0x115,
        WM_INITMENU = 0x116,
        WM_INITMENUPOPUP = 0x117,
        WM_MENUSELECT = 0x11F,
        WM_MENUCHAR = 0x120,
        WM_ENTERIDLE = 0x121,

        WM_CTLCOLORMSGBOX = 0x132,
        WM_CTLCOLOREDIT = 0x133,
        WM_CTLCOLORLISTBOX = 0x134,
        WM_CTLCOLORBTN = 0x135,
        WM_CTLCOLORDLG = 0x136,
        WM_CTLCOLORSCROLLBAR = 0x137,
        WM_CTLCOLORSTATIC = 0x138,

        WM_MOUSEFIRST = 0x200,
        WM_MOUSEMOVE = 0x200,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_LBUTTONDBLCLK = 0x203,
        WM_RBUTTONDOWN = 0x204,
        WM_RBUTTONUP = 0x205,
        WM_RBUTTONDBLCLK = 0x206,
        WM_MBUTTONDOWN = 0x207,
        WM_MBUTTONUP = 0x208,
        WM_MBUTTONDBLCLK = 0x209,
        WM_MOUSEWHEEL = 0x20A,
        WM_MOUSEHWHEEL = 0x20E,

        WM_PARENTNOTIFY = 0x210,
        WM_ENTERMENULOOP = 0x211,
        WM_EXITMENULOOP = 0x212,
        WM_NEXTMENU = 0x213,
        WM_SIZING = 0x214,
        WM_CAPTURECHANGED = 0x215,
        WM_MOVING = 0x216,
        WM_POWERBROADCAST = 0x218,
        WM_DEVICECHANGE = 0x219,

        WM_MDICREATE = 0x220,
        WM_MDIDESTROY = 0x221,
        WM_MDIACTIVATE = 0x222,
        WM_MDIRESTORE = 0x223,
        WM_MDINEXT = 0x224,
        WM_MDIMAXIMIZE = 0x225,
        WM_MDITILE = 0x226,
        WM_MDICASCADE = 0x227,
        WM_MDIICONARRANGE = 0x228,
        WM_MDIGETACTIVE = 0x229,
        WM_MDISETMENU = 0x230,
        WM_ENTERSIZEMOVE = 0x231,
        WM_EXITSIZEMOVE = 0x232,
        WM_DROPFILES = 0x233,
        WM_MDIREFRESHMENU = 0x234,

        WM_IME_SETCONTEXT = 0x281,
        WM_IME_NOTIFY = 0x282,
        WM_IME_CONTROL = 0x283,
        WM_IME_COMPOSITIONFULL = 0x284,
        WM_IME_SELECT = 0x285,
        WM_IME_CHAR = 0x286,
        WM_IME_KEYDOWN = 0x290,
        WM_IME_KEYUP = 0x291,

        WM_MOUSEHOVER = 0x2A1,
        WM_NCMOUSELEAVE = 0x2A2,
        WM_MOUSELEAVE = 0x2A3,

        WM_CUT = 0x300,
        WM_COPY = 0x301,
        WM_PASTE = 0x302,
        WM_CLEAR = 0x303,
        WM_UNDO = 0x304,

        WM_RENDERFORMAT = 0x305,
        WM_RENDERALLFORMATS = 0x306,
        WM_DESTROYCLIPBOARD = 0x307,
        WM_DRAWCLIPBOARD = 0x308,
        WM_PAINTCLIPBOARD = 0x309,
        WM_VSCROLLCLIPBOARD = 0x30A,
        WM_SIZECLIPBOARD = 0x30B,
        WM_ASKCBFORMATNAME = 0x30C,
        WM_CHANGECBCHAIN = 0x30D,
        WM_HSCROLLCLIPBOARD = 0x30E,
        WM_QUERYNEWPALETTE = 0x30F,
        WM_PALETTEISCHANGING = 0x310,
        WM_PALETTECHANGED = 0x311,

        WM_HOTKEY = 0x312,
        WM_PRINT = 0x317,
        WM_PRINTCLIENT = 0x318,

        WM_HANDHELDFIRST = 0x358,
        WM_HANDHELDLAST = 0x35F,
        WM_PENWINFIRST = 0x380,
        WM_PENWINLAST = 0x38F,
        WM_COALESCE_FIRST = 0x390,
        WM_COALESCE_LAST = 0x39F,
        WM_DDE_FIRST = 0x3E0,
        WM_DDE_INITIATE = 0x3E0,
        WM_DDE_TERMINATE = 0x3E1,
        WM_DDE_ADVISE = 0x3E2,
        WM_DDE_UNADVISE = 0x3E3,
        WM_DDE_ACK = 0x3E4,
        WM_DDE_DATA = 0x3E5,
        WM_DDE_REQUEST = 0x3E6,
        WM_DDE_POKE = 0x3E7,
        WM_DDE_EXECUTE = 0x3E8,
        WM_DDE_LAST = 0x3E8,

        WM_USER = 0x400,
        WM_APP = 0x8000
    }
}
