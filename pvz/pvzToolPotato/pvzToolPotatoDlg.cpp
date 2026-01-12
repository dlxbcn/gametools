
// pvzToolPotatoDlg.cpp: 实现文件
//

#include "pch.h"
#include "framework.h"
#include "pvzToolPotato.h"
#include "pvzToolPotatoDlg.h"
#include "afxdialogex.h"
//#include "tchar.h"
//#include "algorithm"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//static HWND g_hMatchedWnd = NULL;

// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// 对话框数据
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

/*
CString TrimString(const CString& str)
{
	CString strTrimmed = str;
	// 去除开头空格
	strTrimmed.TrimLeft(_T(" "));
	// 去除结尾空格
	strTrimmed.TrimRight(_T(" "));
	return strTrimmed;
}


BOOL CALLBACK EnumWindowsProc(HWND hWnd, LPARAM lParam)
{
	// 跳过隐藏窗口（可选，根据需求调整）
	if (!::IsWindowVisible(hWnd))
		return TRUE;

	// 获取窗口实际标题
	int nTitleLen = ::GetWindowTextLengthW(hWnd);
	if (nTitleLen == 0)
		return TRUE;

	CString strWndTitle;
	::GetWindowTextW(hWnd, strWndTitle.GetBuffer(nTitleLen + 1), nTitleLen + 1);
	strWndTitle.ReleaseBuffer();

	// 核心：去除标题首尾空格后匹配
	CString strTrimmedTitle = TrimString(strWndTitle);
	CString strTrimmedTarget = TrimString(_T("植物大战僵尸杂交版v3."));

	// 匹配（不区分大小写，进一步提高容错）
	if (strTrimmedTitle.CompareNoCase(strTrimmedTarget) == 0)
	{
		g_hMatchedWnd = hWnd; // 找到匹配窗口
		return FALSE; // 停止枚举
	}

	return TRUE; // 继续枚举下一个窗口
}
*/

HANDLE GetGameProcessId()
{
	HWND hWnd = ::FindWindowW(NULL, _T("植物大战僵尸杂交版v3.14"));
	if (hWnd == NULL)
	{
		AfxMessageBox(_T("未找到游戏"), MB_OK | MB_ICONERROR);
		return NULL;
	}
	//::EnumWindows(EnumWindowsProc, 0);
	//if (g_hMatchedWnd == NULL)
	//{
	//	AfxMessageBox(_T("未找到游戏窗口！"), MB_OK|MB_ICONERROR);
	//	return NULL;
	//}
	
	DWORD dwProcessId = 0;
	::GetWindowThreadProcessId(hWnd, &dwProcessId);
	if (dwProcessId == 0)
	{
		AfxMessageBox(_T("获取进程ID失败！"), MB_OK | MB_ICONERROR);
		return NULL;
	}
	HANDLE hProcess = ::OpenProcess(PROCESS_ALL_ACCESS, FALSE, dwProcessId);
	if (hProcess == NULL)
	{
		AfxMessageBox(_T("读取游戏进程失败！"), MB_OK | MB_ICONERROR);
		return NULL;
	}
	return hProcess;
}

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CpvzToolPotatoDlg 对话框



CpvzToolPotatoDlg::CpvzToolPotatoDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_PVZTOOLPOTATO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDI_ICON1);
}

void CpvzToolPotatoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CpvzToolPotatoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDOK, &CpvzToolPotatoDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDCANCEL, &CpvzToolPotatoDlg::OnBnClickedCancel)
	ON_NOTIFY(NM_CLICK, IDC_SYSLINK_About, &CpvzToolPotatoDlg::OnNMClickSyslinkAbout)
	ON_BN_CLICKED(IDC_BUTTON_ChangeSun, &CpvzToolPotatoDlg::OnBnClickedButtonChangesun)
	ON_BN_CLICKED(IDC_BUTTON_SilverCoin, &CpvzToolPotatoDlg::OnBnClickedButtonSilvercoin)
END_MESSAGE_MAP()


// CpvzToolPotatoDlg 消息处理程序

BOOL CpvzToolPotatoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != nullptr)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。  当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CpvzToolPotatoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。  对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CpvzToolPotatoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CpvzToolPotatoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CpvzToolPotatoDlg::OnBnClickedOk()
{
	CDialogEx::OnOK();
}

void CpvzToolPotatoDlg::OnBnClickedCancel()
{
	CDialogEx::OnCancel();
}


void CpvzToolPotatoDlg::OnNMClickSyslinkAbout(NMHDR* pNMHDR, LRESULT* pResult)
{
	// 关于
	*pResult = 0;
	CAboutDlg dlgAbout;
	dlgAbout.DoModal();
}



void CpvzToolPotatoDlg::OnBnClickedButtonChangesun()
{
	// 修改阳光
	HANDLE hProcess = GetGameProcessId();
	if (hProcess == NULL) {
		return;
	}
	const LPCVOID addr1 = (LPCVOID)(0x00400000 + 0x002A9EC0);
	DWORD_PTR addrValue1 = 0;
	SIZE_T dwActualRead = 0;
	BOOL bReadSuccess = ::ReadProcessMemory(hProcess, addr1, &addrValue1, sizeof(DWORD_PTR), &dwActualRead);
	if (!bReadSuccess || dwActualRead == 0)
	{
		AfxMessageBox(_T("读取阳光地址数据失败！"), MB_OK|MB_ICONERROR);
		goto end;
	}

	DWORD_PTR addr2 = addrValue1 + 0x00000768;
	DWORD_PTR addrValue2 = 0;
	bReadSuccess = ::ReadProcessMemory(hProcess, (LPCVOID)addr2, &addrValue2, sizeof(DWORD_PTR), &dwActualRead);
	if (!bReadSuccess || dwActualRead == 0)
	{
		AfxMessageBox(_T("读取阳光二级地址数据失败！"), MB_OK | MB_ICONERROR);
		goto end;
	}

	DWORD_PTR addr3 = addrValue2 + 0x00005560;
	DWORD sun = 0;
	bReadSuccess = ::ReadProcessMemory(hProcess, (LPCVOID)addr3, &sun, sizeof(DWORD), &dwActualRead);
	if (!bReadSuccess || dwActualRead == 0)
	{
		AfxMessageBox(_T("读取阳光数据失败！"), MB_OK | MB_ICONERROR);
		goto end;
	}
	sun = 99999;
	SIZE_T write = 0;
	bReadSuccess = ::WriteProcessMemory(hProcess, (LPVOID)addr3, &sun, sizeof(DWORD), &write);
	if (!bReadSuccess || write == 0)
	{
		AfxMessageBox(_T("写入阳光数据失败！"), MB_OK | MB_ICONERROR);
		goto end;
	}
end:
	::CloseHandle(hProcess);
}


void CpvzToolPotatoDlg::OnBnClickedButtonSilvercoin()
{
	// 修改银币
}
