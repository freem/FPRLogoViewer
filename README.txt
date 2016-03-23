Fire Pro Returns Logo Viewer by freem (http://www.ajworld.net/)
================================================================================
Requires .NET 2.0 framework. Might work in Wine on Linux and Mac OS X.

================================================================================
Introduction
================================================================================
This program allows you to view logo files from Fire Pro Returns save files,
as well as export the logos to PNG.

As of the current version (1.0.0.0), the following formats are supported:
- EMS Memory Linker (*.psu) format single game save (952,320 bytes)
- raw save data (913,892 bytes length); typically named one of the following:
 * BISLPM-66082: NTSC-J/Japanese
 * BASLUS-21702: NTSC-U/North America
 * BESLES-55041: PAL/Europe
- raw .bin rips (16,656 bytes in length) from Fire Pro Returns save data.

.max and .vme formats probably won't ever be supported; sorry.

================================================================================
Usage
================================================================================
Upon opening the program, you will see three sections laid out in a row.

Here is a crude ASCII diagram of the main window:
+-----------------------------------------------+
|@ Fire Pro Returns Logo Viewer              _#X|
+-----------------------------------------------+
| File  Help                                    | <- Menu bar
+-----------------------------------------------+
|              |+-Cursor Color-+ +-Color Table-+|
|              ||              | |[0x00      ]V||
|              ||  cursor      | |  color      ||
| logo section ||  color       | |  table      ||
|              ||  swatch      | |  swatch     ||
|              ||              | |             ||
|              |+--------------+ +-------------+|
+-----------------------------------------------+
| No file loaded.                               | <- Status Bar
+-----------------------------------------------+

[File menu]
Open - Select a file for opening.
       If a .psu or raw save is selected, another dialog will appear (see below)
Save - Export the currently loaded logo to a PNG file.
Exit - Get out of here!

[Help menu]
Only contains the About dialog.

[Select Logo dialog]
When opening up a save file with multiple logos, a dialog will appear with the
status of each logo in the save. To load the logo, you may either double click
an item or select the item and press OK. (The Enter key should work too.)

[Logo Section]
This is where the logo is displayed. Hover your mouse over the picture to see
more information about the pixels in the image. You can also click on the image
to view the specified color in the Color Table.

[Cursor Color]
This section contains a panel that changes color based on the cursor's position.

[Color Table]
The palette for the loaded logo is found in this section. Changing the active
item in the drop-down box will change the color of the panel below it.

[Status Bar]
Provides program information, such as notifying when a file has been loaded.
Primarily used for cursor display in the logo section.

An example status:
X:000/127,Y:042/127,V:0x00/000

X - the X position, from 000 to 127 (maximum)
Y - the Y position, from 000 to 127 (maximum)
V - the value at this pixel (palette index 0x00-0x3F)

================================================================================
License
================================================================================
This program is released under the MIT license.
Please see the LICENSE file for more information.
