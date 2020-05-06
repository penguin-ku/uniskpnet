// Copyright 2013 Trimble Navigation Limited. All Rights Reserved.

#include "./stdafx.h"
#include "./resource.h"
#include "./xmloptionsdlg.h"

IMPLEMENT_DYNAMIC(CXMLOptionsDlg, CDialog)
CXMLOptionsDlg::CXMLOptionsDlg(CWnd* parent_ /*=NULL*/)
  : CDialog(CXMLOptionsDlg::IDD, parent_) {
    export_materials_ = true;
    export_faces_ = true;
    export_edges_ = true;
    export_materials_by_layer_ = false;
    export_layers_ = true;
    export_selection_set_ = false;
}

CXMLOptionsDlg::~CXMLOptionsDlg() {
}

void CXMLOptionsDlg::set_model_has_selection_set(bool has_selection_set) {
  model_has_selection_set_ = has_selection_set;
}

void CXMLOptionsDlg::DoDataExchange(CDataExchange* dx) {
  CDialog::DoDataExchange(dx);
  DDX_Check(dx, IDC_CHECK_EXPORT_MATERIALS, export_materials_);
  DDX_Check(dx, IDC_CHECK_EXPORT_FACES, export_faces_);
  DDX_Check(dx, IDC_CHECK_EXPORT_EDGES, export_edges_);
  DDX_Check(dx, IDC_CHECK_EXPORT_MATERIALS_BY_LAYER, export_materials_by_layer_);
  DDX_Check(dx, IDC_CHECK_EXPORT_LAYERS, export_layers_);
  DDX_Check(dx, IDC_CHECK_EXPORT_SELECTIONSET, export_selection_set_);
  DDX_Control(dx, IDC_CHECK_EXPORT_SELECTIONSET, export_selection_set_button_);
}

BOOL CXMLOptionsDlg::OnInitDialog() {
  CDialog::OnInitDialog();
  
  if (model_has_selection_set_ == false) {
    export_selection_set_ = false;
    export_selection_set_button_.EnableWindow(FALSE);
  }
  
  return TRUE;  // return TRUE unless you set the focus to a control
  // EXCEPTION: OCX Property Pages should return FALSE
}

BEGIN_MESSAGE_MAP(CXMLOptionsDlg, CDialog)
END_MESSAGE_MAP()
