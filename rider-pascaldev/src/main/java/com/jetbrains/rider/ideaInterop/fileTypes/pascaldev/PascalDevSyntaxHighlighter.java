package com.jetbrains.rider.ideaInterop.fileTypes.pascaldev;

import com.jetbrains.rider.ideaInterop.fileTypes.RiderDummySyntaxHighlighter;

public class PascalDevSyntaxHighlighter extends RiderDummySyntaxHighlighter {

    public PascalDevSyntaxHighlighter() {
        super(PascalDevLanguage.INSTANCE);
    }
}
