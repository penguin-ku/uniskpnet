// Copyright 2013 Trimble Navigation Ltd. All Rights Reserved.

#ifndef XMLTOSKP_WIN_IMPORTOPTIONSDIALOG_H
#define XMLTOSKP_WIN_IMPORTOPTIONSDIALOG_H

#include "./resource.h"

class ImportOptionsDialog : public CDialog {
DECLARE_DYNAMIC(ImportOptionsDialog)
 public:
  ImportOptionsDialog(CWnd* parent = NULL);
  virtual ~ImportOptionsDialog();

  void set_merge_coplanar_faces(bool merge);
  bool merge_coplanar_faces() const;

  afx_msg void OnBnClickedOk();
  afx_msg void OnBnClickedCancel();
  enum { IDD = IDD_IMPORT_OPTIONS_DIALOG };

 protected:
  virtual void DoDataExchange(CDataExchange* dx);    // DDX/DDV support
  virtual BOOL OnInitDialog();
  DECLARE_MESSAGE_MAP()

 private:
  BOOL merge_coplanar_faces_;
};

#endif // XMLTOSKP_WIN_IMPORTOPTIONSDIALOG_H
