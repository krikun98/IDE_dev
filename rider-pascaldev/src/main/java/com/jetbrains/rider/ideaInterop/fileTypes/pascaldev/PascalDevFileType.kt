package com.jetbrains.rider.ideaInterop.fileTypes.pascaldev

import com.intellij.openapi.fileTypes.LanguageFileType

object PascalDevFileType : LanguageFileType(PascalDevLanguage) {
    override fun getName() = "PascalDev"
    override fun getDefaultExtension() = "pascaldev"
    override fun getDescription() = "PascalDev file"
    override fun getIcon() = null
}
