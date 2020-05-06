// Copyright 2013 Trimble Navigation Limited. All Rights Reserved.

#include "stdafx.h"
#include "./xmlpluginwin.h"
#include "./xmloptionsdlg.h"
#include "./xmlexportresultsdlg.h"

CXmlExporterPluginWin *CXmlExporterPluginWin::s_pInstance = NULL;

CXmlExporterPluginWin::CXmlExporterPluginWin() {
}

CXmlExporterPluginWin *CXmlExporterPluginWin::GetInstance() {
  if (s_pInstance == NULL) {
    s_pInstance = new CXmlExporterPluginWin();
  }
  return s_pInstance;
}

void CXmlExporterPluginWin::DestroyInstance() {
  if (s_pInstance) {
    delete s_pInstance;
    s_pInstance = NULL;
  }
}

void CXmlExporterPluginWin::ShowOptionsDialog(bool model_has_selection) {
  AFX_MANAGE_STATE(AfxGetStaticModuleState());

  // Create dialog and set preferences on dialog
  CXMLOptionsDlg dlg;
  dlg.set_model_has_selection_set(model_has_selection);
  dlg.export_materials_ = m_bExportMaterials == true;
  dlg.export_faces_ = m_bExportFaces == true;
  dlg.export_edges_ = m_bExportEdges == true;
  dlg.export_materials_by_layer_ = m_bExportMaterialsByLayer == true;
  dlg.export_layers_ = m_bExportLayers == true;
  dlg.export_selection_set_ = m_bExportSelectionSet == true;

  // Display dialog
  if (dlg.DoModal() == IDOK) {
    // Save preferences
    m_bExportMaterials = dlg.export_materials_ == TRUE;
    m_bExportFaces = dlg.export_faces_ == TRUE;
    m_bExportEdges = dlg.export_edges_ == TRUE;
    m_bExportMaterialsByLayer = dlg.export_materials_by_layer_ == TRUE;
    m_bExportLayers = dlg.export_layers_ == TRUE;

    m_bExportSelectionSet = dlg.export_selection_set_ == TRUE;
  }
}

static void AppendMessage(int number, UINT msgId, CString& to) {
  if (number > 0) {
    CString tmp;
    tmp.FormatMessage(msgId, number);
    to += tmp;
  }
}

void CXmlExporterPluginWin::ShowSummaryDialog(const std::string& summary) {
  AFX_MANAGE_STATE(AfxGetStaticModuleState());
  CString exported_msg = summary.c_str();
  exported_msg.Replace(_T("\n"), _T("\r\n"));
  CXMLExportResultsDlg dlg;
  dlg.set_message(exported_msg);
  dlg.DoModal();
}
