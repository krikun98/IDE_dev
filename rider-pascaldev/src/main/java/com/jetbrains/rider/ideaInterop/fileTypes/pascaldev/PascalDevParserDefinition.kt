package com.jetbrains.rider.ideaInterop.fileTypes.pascaldev

import com.intellij.lexer.Lexer
import com.intellij.openapi.project.Project
import com.intellij.psi.tree.IElementType
import com.jetbrains.rider.ideaInterop.fileTypes.RiderFileElementType
import com.jetbrains.rider.ideaInterop.fileTypes.RiderParserDefinitionBase
import com.intellij.psi.tree.IFileElementType
import com.jetbrains.rider.ideaInterop.fileTypes.RiderDummyLexer

class PascalDevParserDefinition : RiderParserDefinitionBase(PascalDevFileElementType, PascalDevFileType) {
    companion object {
        val PascalDevElementType = IElementType("RIDER_SPRING", PascalDevLanguage)
        val PascalDevFileElementType = RiderFileElementType("RIDER_SPRING_FILE", PascalDevLanguage, PascalDevElementType)
    }

    override fun createLexer(project: Project?): Lexer = RiderDummyLexer(PascalDevLanguage)
    override fun getFileNodeType(): IFileElementType = PascalDevFileElementType
}
