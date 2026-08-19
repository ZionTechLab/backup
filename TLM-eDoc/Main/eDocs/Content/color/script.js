(function (cp) {
    var element = $(cp);
    if (element.length > 0) {
        element.each(function () {
            var $this = $(this),
                $container = {
                    value: $this.find('.form-control-color-picker-value'),
                    dropdown: $this.find('.form-control-color-picker-dropdown'),
                    items: $this.find('.form-control-color-picker-dropdown > .form-control-color-picker-dropdown-item')
                },
                $input = $this.find('#color');
            $selected = $container.dropdown.find('.form-control-color-picker-dropdown-item.selected');

            if ($selected.length > 0) {
                $container.value.text($selected.text());
                $this.attr('style', $selected.attr('style'));
                $input.val($selected.data('value'));
            }

            $container.items.on('click', function (e) {
                e.preventDefault();
                var el = $(this);
                $container.items.removeClass('selected');
                el.addClass('selected');
                $container.value.text(el.text());
                $this.attr('style', el.attr('style'));
                $input.val(el.data('value'));
                $this.blur();
            });

        });
    }
}('.form-control-color-picker'));