/* 
(c) 2011 Lubomir Krupa, CC BY-ND 3.0
*/
var hoverEffect = true; 
var numberOfScreens = 7; 
$(document).ready(function () {
    var num = numberOfScreens;

    if (hoverEffect) {
        for (i = 1; i <= num; i++) {
            $('<style>#wrapper' + i + ' div.site:hover{border: 1px #fff solid;box-shadow: 0px 0px 5px #fff;margin-left:4px;margin-top:4px;}</style>').appendTo('head');
        };
    };

    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    var left1 = Math.floor((windowWidth - 960) / 2);
    var left2 = left1 - 1040;
    var left3 = left1 - 2080;
    var left4 = left1 - 3120;
    var left5 = left1 - 4140;
    var left6 = left1 - 5160;
    var left7 = left1 - 6180;
    var wrapperTop = Math.floor((windowHeight - 480) / 2) - 60;

    $('#place').css({ 'left': left1, 'top': wrapperTop });
    var wrapperPos = 1;
    $('#wrapper1 input:text').focus();
    var animDone = true;

    function anim1to2() {
        window.parent.selectMenus(2);
        $('#wrapper1 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left2
        }, 1000, 'circEaseOut', function () {
            $('#wrapper2 input:text').focus();
            animDone = true;
            wrapperPos = 2;
        });
        $('#button1to2').hide();
        $('#button2to1').show();
        if (num > 2) {
            $('#button2to3').show();
            $('#button3to2').hide();
        };
    };

    function anim2to1() {
        window.parent.selectMenus(1);
        $('#wrapper2 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left1
        }, 1000, 'circEaseOut', function () {
            $('#wrapper1 input:text').focus();
            animDone = true;
            wrapperPos = 1;
        });
        $('#button1to2').show();
        $('#button2to1').hide();
        if (num > 2) {
            $('#button2to3').hide();
            $('#button3to2').hide();
        };
    };

    function anim2to3() {
        window.parent.selectMenus(3);
        $('#wrapper2 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left3
        }, 1000, 'circEaseOut', function () {
            $('#wrapper3 input:text').focus();
            animDone = true;
            wrapperPos = 3;
        });
        $('#button3to2').show();
        $('#button2to1').hide();
        $('#button2to3').hide();
        $('#button3to4').show();
    };

    function anim3to2() {
        window.parent.selectMenus(2);
        $('#wrapper3 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left2
        }, 1000, 'circEaseOut', function () {
            $('#wrapper2 input:text').focus();
            animDone = true;
            wrapperPos = 2;
        });
        $('#button1to2').hide();
        $('#button3to2').hide();
        $('#button2to1').show();
        $('#button2to3').show();
    };

    function anim3to4() {
        window.parent.selectMenus(4);
        $('#wrapper3 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left4
        }, 1000, 'circEaseOut', function () {
            $('#wrapper4 input:text').focus();
            animDone = true;
            wrapperPos = 4;
        });
        $('#button4to3').show();
        $('#button4to5').show();
        $('#button3to4').hide();
        $('#button5to4').hide();
    };

    function anim4to3() {
        window.parent.selectMenus(3);
        $('#wrapper4 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left3
        }, 1000, 'circEaseOut', function () {
            $('#wrapper3 input:text').focus();
            animDone = true;
            wrapperPos = 3;
        });
        $('#button3to2').show();
        $('#button2to3').hide();
        $('#button4to3').hide();
        $('#button3to4').show();
    };

    function anim4to5() {
        window.parent.selectMenus(5);
        $('#wrapper4 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left5
        }, 1000, 'circEaseOut', function () {
            $('#wrapper5 input:text').focus();
            animDone = true;
            wrapperPos = 5;
        });
        $('#button6to5').hide();
        $('#button5to6').show();
        $('#button5to4').show();
        $('#button4to5').hide();
    };

    function anim5to4() {
        window.parent.selectMenus(4);
        $('#wrapper5 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left4
        }, 1000, 'circEaseOut', function () {
            $('#wrapper4 input:text').focus();
            animDone = true;
            wrapperPos = 4;
        });
        $('#button3to4').hide();
        $('#button5to4').hide();
        $('#button4to3').show();
        $('#button4to5').show();
    };

    function anim5to6() {
        window.parent.selectMenus(6);
        $('#wrapper5 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left6
        }, 1000, 'circEaseOut', function () {
            $('#wrapper6 input:text').focus();
            animDone = true;
            wrapperPos = 6;
        });
        $('#button5to6').hide();
        $('#button6to5').show();
        $('#button6to7').show();
        $('#button7to6').hide();
    };

    function anim6to5() {
        window.parent.selectMenus(5);
        $('#wrapper6 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left5
        }, 1000, 'circEaseOut', function () {
            $('#wrapper5 input:text').focus();
            animDone = true;
            wrapperPos = 5;
        });
        $('#button6to5').hide();
        $('#button5to6').show();
        $('#button5to4').show();
        $('#button4to5').hide();
    };

    function anim6to7() {
        window.parent.selectMenus(7);
        $('#wrapper6 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left7
        }, 1000, 'circEaseOut', function () {
            $('#wrapper7 input:text').focus();
            animDone = true;
            wrapperPos = 7;
        });
        $('#button6to7').hide();
        $('#button7to6').show();
    };

    function anim7to6() {
        window.parent.selectMenus(6);
        $('#wrapper7 input:text').focusout();
        animDone = false;
        $('#place').animate({
            left: left6
        }, 1000, 'circEaseOut', function () {
            $('#wrapper6 input:text').focus();
            animDone = true;
            wrapperPos = 6;
        });
        $('#button5to6').hide();
        $('#button6to5').show();
        $('#button6to7').show();
        $('#button7to6').hide();
    };

    if (num > 1) {
        $('#button1to2').click(function () {
            anim1to2();
        });

        $('#button2to1').click(function () {
            anim2to1();
        });

        if (num > 2) {
            $('#button2to3').click(function () {
                anim2to3();
            });

            $('#button3to2').click(function () {
                anim3to2();
            });
        };
        if (num > 3) {
            $('#button3to4').click(function () {
                anim3to4();
            });

            $('#button4to3').click(function () {
                anim4to3();
            });
        }
        if (num > 4) {
            $('#button4to5').click(function () {
                anim4to5();
            });

            $('#button5to4').click(function () {
                anim5to4();
            });
        }
        if (num > 5) {
            $('#button5to6').click(function () {
                anim5to6();
            });

            $('#button6to5').click(function () {
                anim6to5();
            });
        }
        if (num > 6) {
            $('#button6to7').click(function () {
                anim6to7();
            });

            $('#button7to6').click(function () {
                anim7to6();
            });
        }
    };

    $(document).bind('keydown', function (event) {
        if (event.keyCode == '39' || event.keyCode == '37') {
            event.preventDefault();
        }
        if (event.which == '39' && animDone) {

            if (wrapperPos == 1 && num > 1) {
                anim1to2();
            };
            if (wrapperPos == 2 && num > 2) {
                anim2to3();
            };
            if (wrapperPos == 3 && num > 3) {
                anim3to4();
            }
            if (wrapperPos == 4 && num > 4) {
                anim4to5();
            }
            if (wrapperPos == 5 && num > 5) {
                anim5to6();
            }
            if (wrapperPos == 6 && num > 6) {
                anim6to7();
            }
        };
        if (event.which == '37' && animDone) {

            if (wrapperPos == 3) {
                anim3to2();
            };
            if (wrapperPos == 2) {
                anim2to1();
            };
            if (wrapperPos == 4) {
                anim4to3();
            };
            if (wrapperPos == 5) {
                anim5to4();
            }
            if (wrapperPos == 6) {
                anim6to5();
            }
            if (wrapperPos == 7) {
                anim7to6();
            }
        };
    });

    $(document).mousewheel(function (event, delta) {
        if (delta > 0 && animDone) {
            if (wrapperPos == 3) {
                anim3to2();
            };
            if (wrapperPos == 2) {
                anim2to1();
            };
            if (wrapperPos == 4) {
                anim4to3();
            };
            if (wrapperPos == 5) {
                anim5to4();
            }
            if (wrapperPos == 6) {
                anim6to5();
            }
            if (wrapperPos == 7) {
                anim7to6();
            }
        }
        else if (delta < 0 && animDone) {
            if (wrapperPos == 1 && num > 1) {
                anim1to2();
            };
            if (wrapperPos == 2 && num > 2) {
                anim2to3();
            };
            if (wrapperPos == 3 && num > 3) {
                anim3to4();
            }
            if (wrapperPos == 4 && num > 4) {
                anim4to5();
            }
            if (wrapperPos == 5 && num > 5) {
                anim5to6();
            }
            if (wrapperPos == 6 && num > 6) {
                anim6to7();
            }
        };
        event.preventDefault();
    });
});

