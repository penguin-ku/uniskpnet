// Copyright 2013 Trimble Navigation Ltd. All Rights Reserved.

#ifndef XMLTOSKP_WIN_XMLIMPORTER_H
#define XMLTOSKP_WIN_XMLIMPORTER_H

#ifndef __AFXWIN_H__
  #error "include 'stdafx.h' before including this file for PCH"
#endif

class CXmlImporterApp : public CWinApp {
public:
  CXmlImporterApp();

// Overrides
public:
  virtual BOOL InitInstance();
  virtual int ExitInstance();

  DECLARE_MESSAGE_MAP()
};

#endif // XMLTOSKP_WIN_XMLIMPORTER_H
