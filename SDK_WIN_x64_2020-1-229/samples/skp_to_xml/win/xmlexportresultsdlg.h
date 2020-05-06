// Copyright 2013 Trimble Navigation Limited. All Rights Reserved.

#ifndef SKPTOXML_WIN32_XMLEXPORTERRESULTSDLG_H
#define SKPTOXML_WIN32_XMLEXPORTERRESULTSDLG_H

#include "./resource.h"

class CXMLExportResultsDlg : public CDialog {
  DECLARE_DYNAMIC(CXMLExportResultsDlg)

public:
  CXMLExportResultsDlg(CWnd* parent_ = NULL);   // standard constructor
  virtual ~CXMLExportResultsDlg();
  void set_message(CString msg);

    // Dialog Data
  enum { IDD = IDD_DIALOG_EXPORT_RESULTS };

protected:

  CString	message_;
  virtual void DoDataExchange(CDataExchange* dx);    // DDX/DDV support

  DECLARE_MESSAGE_MAP()
};

#endif // SKPTOXML_WIN32_XMLEXPORTERRESULTSDLG_H
