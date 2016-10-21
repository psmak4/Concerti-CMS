require.config({
	paths: {
		ckeditor: '../../lib/ckeditor/ckeditor',
		concerti: '../../lib/concerti/js',
		jquery: '../../lib/jquery/jquery.min'
	}
});

require(['jquery', 'concerti/modules/alert'], function ($, alert) {
	$(function () {
		alert.init();

		$('.header__toggle').click(function (e) {
			e.preventDefault();
			$('.nav').addClass('nav--visible');
		});

		$('.nav__toggle').click(function (e) {
			e.preventDefault();
			$('.nav').removeClass('nav--visible');
		});
	});
});