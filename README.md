# iHRTF-Spatializer

A audio plugin for Unity based on Native Audio Plugin SDK and SOFA [API_CPP](https://github.com/sofacoustics/API_Cpp) that allow user to load HRTF data from public SOFA database and apply it to Unity audio sources

Installation & Usage:
-------------

Simply copy the plugin folder to your Unity Project. The list of usable commands can be found in the iHRTF.cs file

```
int iHRTF_loadSOFA(string path);

void iHRTF_selectSOFA(int id);

void iHRTF_removeSOFA(int id);

void iHRTF_clearSOFA();

void config(bool interpolation, float gain_db);

```

A sample Unity project is included to demonstrate the usage of the plugin.
If you just want to test out the plugin without rebuild it using Unity, a test build is also included

Screenshot
![Alt text](/Build/player.JPG?raw=true "Player")

* Open your prefered track using the "Open Audio File" button
* Load sofa files using the "..." button
* Up to 4 files can be loaded to 4 slots for fast switching
* The speaker icon can be dragged to change the source position
* "Switch Mode" button to switch between frontal rendering with range of +-60 azimuth, +-40 elevation and 360 rendering


Disclaimer:
-----------
The plugin is still under development so users may experience crashing if the database is not compatible

Acknowledgement:
---------------
* tcarpent for the SOFA Cpp API used to export and import SOFA data in this project
* gkngkc for the simple and easy to use UnityStandaloneFileBrowser