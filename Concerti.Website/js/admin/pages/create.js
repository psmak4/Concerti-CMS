require(['jquery', 'concerti/modules/convertToSlug', 'ckeditor'], function ($, convertToSlug) {
	$(function () {
		var title = $('#Title');
		var slug = $('#Slug');

		title.focus().keyup(function (event) {
			var titleValue = $(this).val();
			slug.val(convertToSlug.execute(titleValue));
		});

		CKEDITOR.replace('Content');
	});
});