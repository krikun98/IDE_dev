@file:Suppress("PackageDirectoryMismatch", "UnusedImport", "unused", "LocalVariableName")
package com.jetbrains.rider.model

import com.jetbrains.rd.framework.*
import com.jetbrains.rd.framework.base.*
import com.jetbrains.rd.framework.impl.*

import com.jetbrains.rd.util.lifetime.*
import com.jetbrains.rd.util.reactive.*
import com.jetbrains.rd.util.string.*
import com.jetbrains.rd.util.*
import kotlin.reflect.KClass



class RdPascalDevModel internal constructor(
) : RdExtBase() {
    //companion
    
    companion object : ISerializersOwner {
        
        override fun registerSerializersCore(serializers: ISerializers) {
        }
        
        
        
        
        const val serializationHash = 8121611681274943773L
    }
    override val serializersOwner: ISerializersOwner get() = RdPascalDevModel
    override val serializationHash: Long get() = RdPascalDevModel.serializationHash
    
    //fields
    //initializer
    //secondary constructor
    //equals trait
    //hash code trait
    //pretty print
    override fun print(printer: PrettyPrinter) {
        printer.println("RdPascalDevModel (")
        printer.print(")")
    }
}
val Solution.rdPascalDevModel get() = getOrCreateExtension("rdPascalDevModel", ::RdPascalDevModel)

