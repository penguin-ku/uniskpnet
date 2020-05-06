// Copyright 2013 Trimble Navigation Limited. All Rights Reserved.

#include "stdafx.h"
#include "./xmlexportresultsdlg.h"


IMPLEMENT_DYNAMIC(CXMLExportResultsDlg, CDialog)
CXMLExportResultsDlg::CXMLExportResultsDlg(CWnd* parent_ /*=NULL*/)
  : CDialog(CXMLExportResultsDlg::IDD, parent_) {
}

CXMLExportResultsDlg::~CXMLExportResultsDlg() {
}

void CXMLExportResultsDlg::DoDataExchange(CDataExchange* dx) {
  CDialog::DoDataExchange(dx);
  DDX_Text(dx, IDC_EDIT_STATS_MESSAGE, message_);
}

BEGIN_MESSAGE_MAP(CXMLExportResultsDlg, CDialog)
END_MESSAGE_MAP()

void CXMLExportResultsDlg::set_message(CString msg) {
    message_ = msg;
}
