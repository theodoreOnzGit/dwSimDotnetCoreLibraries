# This is the IXmlFilePathString interface and implementation folder

I wrote this code mainly so that the experiments
that i did trying to find the relative filepath of the xml
libraries would not be wasted

There were several methods i tried in unit testing
Firstly using the assmebly method to get filepath
second with the filesystem method

thirdly with the AppDomain method

## interface structure

This is supposed to return a filepath for xml library

## issues

I could not find an elegant solution for 
returning the file path of the xml when i squeezed it
into a visual basic source code folder

## implementations

the filepath string can be returned using
the assembly method in System.Reflection

or the filesystem method using visualbasic io

or use the directory class in System.IO


## tests
