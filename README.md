# MkBin
**MkBin** provides a way to procuce binary files or to represent binary files using Unicode text.
MkBin is primarily a tool for Commodore 64 developers who uses Windows as development platform,
who want to be able to represent machine code, sprite data, or any other asset as text.
But it can be used by anyone who wants to represent any binary data as text.

The program takes a source file and a target file. The source file is a text representation
of a binary file, and the target file is the binary file that will be written.

`MkBin -source MyTextFile.txt -target BinaryFileToBeCreated.bin`

Text representations can be generated from binary files by adding the `-totext` argument.

`MkBin -source [source filename] -target [target filename] -totext`


There is also an experimentation mode where you can type in expressions and get feedback
on what bytes would have been generated, as text.

`MkBin -prompt`

```
Text to bin: long 1 2 3
01 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 03 00 00 00 00 00 00 00
Ok.
Text to bin:
```

Start without arguments to show the graphical user interface, or with `-nohide` to show the user interface and leave the console window visible.

For a description of how the text-to-binary parser works:

`MkBin -help`

## Datatypes

All numbers are expected to be bytes (and cannot be larger than 255) unless the type
is changed using the keywords `short`, `ushort`, `int`, `uint`, `long`, `ulong`. To restore
to byte, use the keyword `byte`.

`1 1 1` gives three bytes: `01 01 01`.

`1 int 1 1` gives nine bytes, because the first 1 requires one byte and
the last two bytes requires four bytes each: `01 01 00 00 00 01 00 00 00`.

## Examples

Here is a couple of examples of inputs and a text representation of the output.

### Three 16-bit numbers

This example shows how three 16-bit numbers can be represented as text.

**Input:**

`short 1 2 3`

**output:**

`01 00 02 00 03 00`

### A machine code program

This example is a complete machine code program for the Commodore 64 that changes the background color to black.
It is located in memory at 4096, so if loaded to a Commodore 64, it can be started using `SYS 4096`.

**Input:**

```
ushort 4096 byte 169 0
141 ushort 53281
byte 96
```

**output:**

`00 10 A9 00 8D 21 D0 60`

### Incorrect examples

This will not work because 300 doesn't fit in a *byte*: `100 200 300`

This will not work because 40.000 doesn't fit in a *short*: `10000 20000 30000 40000`

## Supported control words

The following control words will affect the output format of the succeeding numbers:

`byte` (default), `short`, `ushort`, `int`, `uint`, `long` and `ulong`.