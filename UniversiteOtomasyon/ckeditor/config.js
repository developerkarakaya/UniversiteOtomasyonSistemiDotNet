/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
    config.language = 'tr'; //CKEDITOR arayüz dili
    config.uiColor = '#e2e2e2';// CKEDITOR arayüz rengi
    config.colorButton_colors = '000000,FF0000,00FF00,0000FF';//yazı renk butonunun renkleri
    config.colorButton_enableMore = false; //belirtilenler dışında renk  seçimini  engelleme
    config.contentsLanguage = 'tr';//Editör içeriği oluşturmak için kullanılan yazı dilinin dil kodu.
     

    config.filebrowserBrowseUrl= '~/ckeditor/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl= '~/ckeditor/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl= '~/ckeditor/ckeditor/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl= '~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl= '~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl= '~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
