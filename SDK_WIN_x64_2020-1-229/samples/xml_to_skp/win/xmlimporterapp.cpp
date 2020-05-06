// Copyright 2013 Trimble Navigation Ltd. All Rights Reserved.

#include "stdafx.h"
#include "./xmlimporterapp.h"
#include "./xmlpluginwin.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// Put this Macro at the start of any function which uses MFC.  Technically,
// we probably only need this if the underlying MFC routine accesses any
// resources or other MFC state.  Simple operations on CString probably do
// not need this, but I'm using just in case.
#define MANAGE_STATE AFX_MANAGE_STATE(AfxGetStaticModuleState())
//
//		Please see MFC Technical Notes 33 and 58 for additional
//		details.
//

// CXmlImporterApp
BEGIN_MESSAGE_MAP(CXmlImporterApp, CWinApp)
END_MESSAGE_MAP()


CXmlImporterApp::CXmlImporterApp() {
}

// The one and only CXmlImporterApp object
CXmlImporterApp theApp;


// CXmlImporterApp initialization
BOOL CXmlImporterApp::InitInstance() {
  MANAGE_STATE;

  CWinApp::InitInstance();
  return TRUE;
}

int CXmlImporterApp::ExitInstance() {
  MANAGE_STATE;

  CXmlImporterPluginWin::DestroyInstance();
  return (0);
}

// This is the only exported function.  It simply returns a pointer to the
// importer interface.
SketchUpModelImporterInterface* GetSketchUpModelImporterInterface() {
  return CXmlImporterPluginWin::GetInstance();
}