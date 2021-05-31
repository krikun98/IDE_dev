package com.jetbrains.rider.ideaInterop.fileTypes.pascaldev

import com.jetbrains.rider.ideaInterop.fileTypes.RiderLanguageBase

abstract class PascalDevLanguageBase(name: String) : RiderLanguageBase(name, name) {
    override fun isCaseSensitive() = true
}

object PascalDevLanguage : PascalDevLanguageBase("PascalDev")
