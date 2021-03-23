# MkBin
**MkBin** provides a way to procuce binary files or to represent binary files using Unicode text.
MkBin is primarily a tool for C64 developers who uses Windows as development platform, but
it can be used bu anyone who wants to represent a binary file as text.

The program takes a source file and a target file. The source file is a text representation
of a binary file, and the target file is the binary file that will be written.

`MkBin -source MyTextFile.txt -target BinaryFileToBeCreated.bin`

There is also an experimentation mode where you can type in expressions and get feedback
on what bytes would have been generated, as text.

`MkBin -prompt`

```
Text to bin: long 1 2 3
01 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 03 00 00 00 00 00 00 00
Ok.
Text to bin:
```

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

Here are three examples of inputs and a text representation of the output.

### Input

