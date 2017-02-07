var ImageUtil = {
    isValidImage: function (fileName, allowExtensions) {
        var sFileName = fileName;//input.value;
        var _validFileExtensions = allowExtensions;//[".jpg", ".jpeg", ".bmp", ".gif", ".png"];

        if (sFileName.length <= 0) return false;

        //var blnValid = false;
        for (var j = 0; j < _validFileExtensions.length; j++) {
            var sCurExtension = _validFileExtensions[j];
            if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                return true;
                //blnValid = true;
                //break;
            }
        }

        return false;
    },

    checkValid: function (input, onSuccess) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            var image = new Image();
            
            reader.readAsDataURL(input.files[0]);
            reader.onload = function (_file) {
                //image.src = _file.target.result;              // url.createObjectURL(file);
                //image.onload = function () {
                //    debugger;
                //    var w = this.width,
                //        h = this.height;
                //    if (validSize.height > h || validSize.width > w) {
                //        var expectedDimension = { width: validSize.width, height: validSize.height };
                //        var actualDimension = { width: w, height: h };
                //        onInvalid(expectedDimension, actualDimension);
                //    }
                //    else {
                        onSuccess(image.src);
                    //}
                };
            };
        }
    },

    checkValidSize: function (input, device, deviceImageDimension, onSuccess, onInvalid) {
        debugger;
        if (input.files && input.files[0]) {
            var file = input.files[0];
            var reader = new FileReader();
            var image = new Image();
            var isValidSize = true;
            var validSize = deviceImageDimension;
            //    {
            //    android : {
            //        width : 800, height : 596
            //    },
            //    iphone : {
            //        width: 641, height: 598
            //    },
            //    ipad : {
            //        width: 1536, height: 1244
            //    }
            //};

            var size = validSize.android;
            switch (device) {
                case 'android':
                    size = validSize.android;
                    break;
                case 'iphone':
                    size = validSize.iphone;
                    break;
                case 'ipad':
                    size = validSize.ipad;
                    break;

            }


            reader.readAsDataURL(input.files[0]);
            reader.onload = function (_file) {
                image.src = _file.target.result;              // url.createObjectURL(file);
                image.onload = function () {
                    var w = this.width,
                        h = this.height,
                        t = file.type,                           // ext only: // file.type.split('/')[1],
                        n = file.name,
                        s = ~~(file.size / 1024) + 'KB';
                    if (size.height != h || size.width != w) {
                        var expectedDimension = { width: size.width, height: size.height };
                        var actualDimension = { width: w, height: h };
                        onInvalid(device, expectedDimension, actualDimension);
                    }
                    else {
                        onSuccess(image.src);
                    }
                };
            };
        }
    },

    checkValidSizeArray: function (input, count, device, deviceImageDimension, onSuccess, onInvalid) {
        debugger;
        if (input.files && input.files[count]) {
            var file = input.files[count];
            var reader = new FileReader();
            var image = new Image();
            var isValidSize = true;
            var validSize = deviceImageDimension;
            //    {
            //    android : {
            //        width : 800, height : 596
            //    },
            //    iphone : {
            //        width: 641, height: 598
            //    },
            //    ipad : {
            //        width: 1536, height: 1244
            //    }
            //};

            var size = validSize.android;
            switch (device) {
                case 'android':
                    size = validSize.android;
                    break;
                case 'iphone':
                    size = validSize.iphone;
                    break;
                case 'ipad':
                    size = validSize.ipad;
                    break;

            }

            
            reader.onload = function (_file) {
                              // url.createObjectURL(file);
                image.onload = function () {
                    var w = this.width,
                        h = this.height,
                        t = file.type,                           // ext only: // file.type.split('/')[1],
                        n = file.name,
                        s = ~~(file.size / 1024) + 'KB';
                    //debugger;
                    if (size.height != h || size.width != w) {
                        var expectedDimension = { width: size.width, height: size.height };
                        var actualDimension = { width: w, height: h };
                        onInvalid(device, expectedDimension, actualDimension);
                    }
                    else {

                        onSuccess(image.src, count);
                    }
                };

                image.src = _file.target.result;
            };
            reader.readAsDataURL(file);
        }
    }
}