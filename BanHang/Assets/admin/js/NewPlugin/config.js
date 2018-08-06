/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.syntaxhightlight_lang = 'cshap';
    config.syntaxhightlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Assets/Admin/js/Plugins/core/connector/aspx/connector.aspx?command = QuickUpload & Type=File';
    config.filebrowserImageUploadUrl = '/Anh';
    config.filebrowserFlashUploadUrl ='/Assets/Admin/js/Plugins/core/connector/aspx/connector.aspx?command = QuickUpload & Type=Flash';
    CKFinder.setupCKEditor(null, '/Assets/Admin/js/Plugins/ckfinder');
};
