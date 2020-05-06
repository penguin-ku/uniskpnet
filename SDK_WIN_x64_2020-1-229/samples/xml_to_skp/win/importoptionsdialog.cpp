// Copyright 2013 Trimble Navigation Ltd. All Rights Reserved.

#include "stdafx.h"
#include "./importoptionsdialog.h"

IMPLEMENT_DYNAMIC(ImportOptionsDialog, CDialog)

ImportOptionsDialog::ImportOptionsDialog(CWnd* parent)
    : CDialog(ImportOptionsDialog::IDD, parent) {
  merge_coplanar_faces_ = false;
}

ImportOptionsDialog::~ImportOptionsDialog() {
}

void ImportOptionsDialog::set_merge_coplanar_faces(bool merge) {
  merge_coplanar_faces_ = merge;
}

bool ImportOptionsDialog::merge_coplanar_faces() const {
  return !!merge_coplanar_faces_;
}

void ImportOptionsDialog::DoDataExchange(CDataExchange* dx) {
  CDialog::DoDataExchange(dx);
  DDX_Check(dx, IDC_MERGE_COPLANAR_FACES, merge_coplanar_faces_);
}

BEGIN_MESSAGE_MAP(ImportOptionsDialog, CDialog)
  ON_BN_CLICKED(IDOK, &ImportOptionsDialog::OnBnClickedOk)
  ON_BN_CLICKED(IDCANCEL, &ImportOptionsDialog::OnBnClickedCancel)
END_MESSAGE_MAP()


// ImportOptionsDialog message handlers

void ImportOptionsDialog::OnBnClickedOk() {
  UpdateData(TRUE);
  OnOK();
}

void ImportOptionsDialog::OnBnClickedCancel() {
  OnCancel();
}

BOOL ImportOptionsDialog::OnInitDialog() {
  CDialog::OnInitDialog();
  return TRUE;
}

