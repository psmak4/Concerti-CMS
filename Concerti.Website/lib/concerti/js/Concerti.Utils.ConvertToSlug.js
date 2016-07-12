var Concerti = Concerti || {};
Concerti.Utils = Concerti.Utils || {
	ConvertToSlug: function (text)
	{
		return text.toString().toLowerCase()
		  .replace(/\s+/g, '-')
		  .replace(/[^\w\-]+/g, '')
		  .replace(/\-\-+/g, '-')
		  .replace(/^-+/, '')
		  .replace(/-+$/, '');
	}
};
