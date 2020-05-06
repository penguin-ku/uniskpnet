// Copyright 2013-2019 Trimble, Inc. All Rights Reserved.

#ifndef XMLTOSKP_WIN_XMLPLUGINWIN_H
#define XMLTOSKP_WIN_XMLPLUGINWIN_H

#include "../plugin/xmlplugin.h"

class CXmlImporterPluginWin : public CXmlImporterPlugin {
 public:
  static CXmlImporterPluginWin *GetInstance();
  static void DestroyInstance();

  CXmlImporterPluginWin() {}
  virtual ~CXmlImporterPluginWin() {}

  // Most of the plugin interface is provided by our base class but show
  // options requires platform specific UI.
  SketchUpOptionsDialogResponse ShowOptionsDialog() override;

 protected:
  static CXmlImporterPluginWin *s_pInstance;
};

#endif // XMLTOSKP_WIN_XMLPLUGINWIN_H
