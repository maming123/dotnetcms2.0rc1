function ck(Obj,w,h) {
    var a1 = document.getElementById("a1");
    if (a1 == undefined || a1 == null) {
        document.write("<div id=\"a1\"></div>");
    }
    var flashvars = {
        f: '', //视频地址
        a: '', //调用时的参数，只有当s>0的时候有效
        s: '0', //调用方式，0=普通方法（f=视频地址），1=网址形式,2=xml形式，3=swf形式(s>0时f=网址，配合a来完成对地址的组装)
        c: '0', //是否读取文本配置,0不是，1是
        x: '', //调用xml风格路径，为空的话将使用ckplayer.js的配置
        i: '', //初始图片地址
        d: '', //暂停时播放的广告，swf/图片,多个用竖线隔开，图片要加链接地址，没有的时候留空就行
        u: '', //暂停时如果是图片的话，加个链接地址
        l: '', //前置广告，swf/图片/视频，多个用竖线隔开，图片和视频要加链接地址
        r: '', //前置广告的链接地址，多个用竖线隔开，没有的留空
        t: '', //视频开始前播放swf/图片时的时间，多个用竖线隔开
        y: '', //这里是使用网址形式调用广告地址时使用，前提是要设置l的值为空
        z: '', //缓冲广告，只能放一个，swf格式
        e: '2', //视频结束后的动作，0是调用js函数，1是循环播放，2是暂停播放，3是调用视频推荐列表的插件，4是清除视频流并调用js功能和1差不多
        v: '80', //默认音量，0-100之间
        p: '0', //视频默认0是暂停，1是播放
        h: '4', //播放http视频流时采用何种拖动方法，=0不使用任意拖动，=1是使用按关键帧，=2是按时间点，=3是自动判断按什么(如果视频格式是.mp4就按关键帧，.flv就按关键时间)，=4也是自动判断(只要包含字符mp4就按mp4来，只要包含字符flv就按flv来)
        q: '', //视频流拖动时参考函数，默认是start
        m: '0', //默认是否采用点击播放按钮后再加载视频，0不是，1是,设置成1时不要有前置广告
        g: '', //视频直接g秒开始播放
        j: '', //视频提前j秒结束
        k: '', //提示点时间，如 30|60鼠标经过进度栏30秒，60秒会提示n指定的相应的文字
        n: '', //提示点文字，跟k配合使用，如 提示点1|提示点2
        b: '0x000', //播放器的背景色，如果不设置的话将默认透明
        w: '', //指定调用自己配置的文本文件,不指定将默认调用和播放器同名的txt文件
        //调用播放器的所有参数列表结束
        //以下为自定义的播放器参数用来在插件里引用的
        my_url: 'ckhtm'//本页面地址
        //调用自定义播放器参数结束
    };
    if (Obj) {
        for (var k in Obj) {
            flashvars[k] = Obj[k];
        }
    }
    var params = { bgcolor: '#000000', allowFullScreen: true, allowScriptAccess: 'always' };
    var attributes = { id: 'ckplayer_a1', name: 'ckplayer_a1' };
    swfobject.embedSWF('/ckplayer/ckplayer.swf', 'a1', w, h, '9.0.0', '/ckplayer/expressInstall.swf', flashvars, params, attributes);
    swfobject.getObjectById('ckplayer_a1').ckplayer_whxy(w, h, 0, 0);
}

function playerstop() {
    //只有当调用视频播放器时设置e=0或4时会有效果
    alert('播放完成');
}
function aboutstr(str, f) {//查看str字符里是否有f
    var about = false;
    var strarray = new Array();
    var farray = new Array();
    farray = f.split(",");
    if (str) {
        for (var i = 0; i < farray.length; i++) {
            strarray = str.split(farray[i]);
            if (strarray.length > 1) {
                about = true;
                break;
            }
        }
    }
    return about;
}