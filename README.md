# 📁 EruStudio – File & Worksheet Manager

**EruStudio** is a powerful Windows Forms application designed for streamlined file/folder management and Excel worksheet consolidation. Developed in **Visual Studio 2022**, it features a modern and intuitive interface aimed at professionals, office users, and power users who frequently work with structured data and complex directories.

---

## ✨ Key Features

### 📊 Excel Worksheet Consolidation
- Merge multiple worksheets into a single consolidated sheet.
- Automatically matches headers across sheets.
- Converts formulas to static values for stability.

### 🗂 File and Folder Batch Operations
- **Rename**: Use Excel templates to batch rename files or folders.
- **Move**: Relocate files/folders to new destinations based on provided paths.
- **Zip**: Compress selected files/folders as defined in a template.

### 🔍 Intelligent File & Folder Search
- Locate files/folders using keyword-based search.
- 3-phase search: Folder names → File names → PDF content.
- Optionally copy matching results to a selected destination.

### 📝 PDF Renamer with Excel Export ✅
- Extract names from PDFs by defining "Before" and "After" text markers.
- Rename files based on extracted text + optional suffix.
- Tracks renamed files.
- **Export rename results to Excel**:
  - Column A: Original file name
  - Column B: New file name

---

## 🆕 Latest Update

- Added **PDF Renamer** with support for extracting names from content and renaming files accordingly.
- **Export to Excel**: Save a log of renamed files (before → after).
- Displays how many PDF files are ready for renaming upon folder selection.
- Disables user input while the renaming process is running to prevent errors.

---

## 🧰 How It Works

### 🔧 For File/Folder Operations
1. **Select Main Folder** – Choose the directory to process.
2. **File/Folder Checkboxes** – Choose whether to process Files, Folders, or both.
3. **Select Modifier** – Select what operation to perform: Rename, Move, or Zip.
4. **Export Template** – Download an Excel template based on your selected operation.
5. **Import Template** – After editing the template, upload it back to the app.
6. **Run Modifier** – Execute the selected action based on the uploaded template.

### 📝 For PDF Renamer
1. **Select Folder** – Choose a folder containing PDF files.
2. **Enter Text Markers** – Input the "Before" and "After" text to extract names.
3. **Set Page Limit** – Define how many pages to search in each PDF.
4. **Add Optional Suffix** – Append text after the extracted name if needed.
5. **Click Rename** – The app processes files and renames them.
6. **Download Result** – Export the rename history to an Excel file.

### 📑 For Worksheet Consolidation
1. **Import Workbook** – Load a workbook with multiple sheets.
2. **Automatic Merge** – The app merges data based on matching headers.
3. **Export Result** – Save the unified data into a single sheet.

---

## 📦 Installation

1. Visit the [Releases](https://github.com/jhudel26/EruStudio/releases/tag/V.0.1.3) page.
2. Download the latest `.exe` installer.
3. Run the installer and follow the on-screen instructions.

---

## 🧾 Additional Notes

- A desktop icon is included in the installation build.
- A `README` file is displayed after installation.
- A [LICENSE](https://github.com/jhudel26/EruStudio/blob/master/LICENSE.txt) file is bundled with the app.

---

## 🔒 License

This project is licensed under the **MIT License**. See the [LICENSE](https://github.com/jhudel26/EruStudio/blob/master/LICENSE.txt) file for full terms.

---

## 🤝 Contributions

Contributions, bug reports, and feature requests are welcome!  
Please feel free to fork the repository, submit pull requests, or open issues.

---

## 📬 Contact

Developed by **Jhudel Orola**  

