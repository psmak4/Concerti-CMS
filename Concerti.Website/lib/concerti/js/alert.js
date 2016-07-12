$(function () {
	$('.alert__dismiss-icon').click(function (event) {
		event.preventDefault();

		var parent = $(this).closest('.alert');
		parent.remove();
	});
});