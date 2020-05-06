// Copyright 2013 Trimble Navigation Limited. All Rights Reserved.

#ifndef SKPTOXML_WIN_XMLOPTIONSDLG_H
#define SKPTOXML_WIN_XMLOPTIONSDLG_H

#include "./resource.h"

class CXMLOptionsDlg : public CDialog
{
  DECLARE_DYNAMIC(CXMLOptionsDlg)

public:
  CXMLOptionsDlg(CWnd* parent_ = NULL);   // standard constructor
  virtual ~CXMLOptionsDlg();

  void set_model_has_selection_set(bool has_selection_set);

// Dialog Data
  enum { IDD = IDD_DIALOG_EXPORT_OPTIONS };
    BOOL export_materials_;
    BOOL export_faces_;
    BOOL export_edges_;
    BOOL export_materials_by_layer_;
    BOOL export_layers_;
    BOOL export_selection_set_;
    CButton export_selection_set_button_;

protected:
  virtual void DoDataExchange(CDataExchange* dx);    // DDX/DDV support
  virtual BOOL OnInitDialog();

  DECLARE_MESSAGE_MAP()
  
 private:
  bool model_has_selection_set_;
};

#endif // SKPTOXML_WIN_XMLOPTIONSDLG_H
