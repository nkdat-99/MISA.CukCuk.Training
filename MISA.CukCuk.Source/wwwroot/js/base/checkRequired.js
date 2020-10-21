var validData = {
    /**
    * Kiểm tra các trường dữ liệu bắt buộc nhập
    * Author: NKĐạt
    * @param {object} input selector
    * Date: 2/10/2020
    * */
    validateRequired: function (input) {
        var value = $(input).val();
        if (!value) {
            $(input).addClass('required-error');
            $(input).attr("title", "Bạn phải nhập thông tin này");
            $(input).attr("placeholder", "Bạn phải nhập thông tin này");
            return true; //Không xét yêu cầu nhập ở JS, xét required trên service.
        } else {
            $(input).removeClass('required-error');
            $(input).removeClass("title");
            return true;
        }
    },
}