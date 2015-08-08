# VisualStudioCodeCoverageResultConverter
Convert Visual Studio Code Coverage Binary Result File to XML Format

There are two test framework in visual studio, mstest and vstest.

if you use vstest to generate code coverage result like that:

    vstest.console.exe UnitTestProject1.dll /Settings:"test.runsettings" /Enablecodecoverage /Logger:trx

you can use CodeCoverage.exe at (your visual studio install path)\Team Tools\Dynamic Code Coverage Tools\ to convert result file to xml.

    CodeCoverage.exe analyze /output:"CodeCoverage.xml" "data.coverage"

if you use mstest to generate code coverage result like that:

    mstest /testcontainer:"UnitTestProject1.dll" /testsettings:"Unittest.testsettings" /resultsfile:"Results.trx"

this data.coverage can't convert by visual studio's CodeCoverage.exe

use this tool instead

    VisualStudioCodeCoverageResultConverter.exe /input:data.coverage /output:Result.coveragexml
