$(function () {
	$('.dropdown__button').click(function (event) {
		event.preventDefault();

		var parent = $(this).closest('.dropdown');
		$('.dropdown--show').not(parent).removeClass('dropdown--show');
		parent.toggleClass('dropdown--show');
	});

	$(window).click(function (event) {
		if (!event.target.matches('.dropdown__button, .dropdown__button span')) {
			$('.dropdown--show').removeClass('dropdown--show');
		}
	});
});
