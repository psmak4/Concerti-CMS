require.config({
	paths: {
		ckeditor: '../../lib/ckeditor/ckeditor',
		concerti: '../../lib/concerti/js',
		jquery: '../../lib/jquery/jquery.min'
	}
});

require(['jquery', 'concerti/modules/alert'], function ($, alert) {
	alert.init();
});