// Copyright 2013-2019 Trimble, Inc. All Rights Reserved.

#include "stdafx.h"
#include "./xmlpluginwin.h"
#include "./importoptionsdialog.h"

CXmlImporterPluginWin *CXmlImporterPluginWin::s_pInstance = NULL;

CXmlImporterPluginWin *CXmlImporterPluginWin::GetInstance() {
  if (s_pInstance == NULL) {
    s_pInstance = new CXmlImporterPluginWin();
  }
  return s_pInstance;
}

void CXmlImporterPluginWin::DestroyInstance() {
  if (s_pInstance) {
    delete s_pInstance;
    s_pInstance = NULL;
  }
}

SketchUpOptionsDialogResponse CXmlImporterPluginWin::ShowOptionsDialog() {
  AFX_MANAGE_STATE(AfxGetStaticModuleState());

  // Options can be read from a file here.

  // Display dialog
  ImportOptionsDialog dlg;
  dlg.set_merge_coplanar_faces(options_.merge_coplanar_faces());
  if (IDOK == dlg.DoModal()) {
    options_.set_merge_coplanar_faces(dlg.merge_coplanar_faces());
    // Options can be persisted to a file here.
	
	// Return options closed with Okay button.
    return IMPORTER_OPTIONS_ACCEPTED;
  }
  // Options closed with 'x' or cancel buttons.
  return IMPORTER_OPTIONS_CANCELLED;
}
