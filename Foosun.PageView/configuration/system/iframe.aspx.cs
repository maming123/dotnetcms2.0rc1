using System;

public partial class configuration_system_iframe : Foosun.PageBasic.DialogPage {
	public configuration_system_iframe() {
		BrowserAuthor = EnumDialogAuthority.ForAdmin | EnumDialogAuthority.ForPerson;
	}
	public string Str_dirMana = Foosun.Config.UIConfig.dirDumm;//获取用户虚拟路径
	protected void Page_Load(object sender, EventArgs e) {
		if (!IsPostBack) {
			Response.CacheControl = "no-cache";
		}
		string sh = Request.QueryString["heights"];
		select_iframe.InnerHtml = select_iframelist(sh);
	}
	string select_iframelist(string sh) {
		if (Str_dirMana.Trim() != "") {
			Str_dirMana = "/" + Str_dirMana;
		}
		string liststr = "";
		string srcstr = "";
		string rq = Request.QueryString["FileType"];
        string ControlName = Request.QueryString["controlName"];
		string arrrq = rq.Split('|')[0];
		switch (arrrq) {
			case "file":
                srcstr = Str_dirMana + "/configuration/system/SelectFiles.aspx?FileType=file&controlName=" + ControlName;
				break;
			case "pic":
                srcstr = Str_dirMana + "/configuration/system/SelectFiles.aspx?FileType=pic&controlName=" + ControlName;
				break;
			case "picEdit":
                srcstr = Str_dirMana + "/configuration/system/SelectFiles.aspx?FileType=pic&Edit=1&controlName=" + ControlName;
				break;
			case "templet":
                srcstr = Str_dirMana + "/configuration/system/SelectFiles.aspx?FileType=templet&controlName=" + ControlName;
				break;
			case "date":
                srcstr = Str_dirMana + "/configuration/system/dateTime.aspx?controlName=" + ControlName;
				break;
			case "path":
                srcstr = Str_dirMana + "/configuration/system/selectPath.aspx?Path=" + rq.Replace("path|", "") + "&controlName=" + ControlName;
				break;
			case "newsclass":
                srcstr = Str_dirMana + "/configuration/system/SelectNewsClass.aspx?controlName=" + ControlName;
				break;
			case "multinewsclass":
                srcstr = Str_dirMana + "/configuration/system/SelectNewsClass.aspx?multi=true&controlName=" + ControlName;
				break;
			case "special":
                srcstr = Str_dirMana + "/configuration/system/SelectNewsSpecial.aspx?controlName=" + ControlName;
				break;
			case "newsspecial":
				srcstr = Str_dirMana + "/configuration/system/selectspecial.aspx?controlName=" + ControlName;
				break;
			case "user_file":
                srcstr = Str_dirMana + "/configuration/system/selectuserpic.aspx?FileType=user_file&controlName=" + ControlName;
				break;
			case "user_pic":
                srcstr = Str_dirMana + "/configuration/system/selectuserpic.aspx?FileType=user_pic&controlName=" + ControlName;
				break;
			case "user_Edit":
                srcstr = Str_dirMana + "/configuration/system/selectuserpic.aspx?FileType=user_pic&Edit=1&controlName=" + ControlName;
				break;
			case "user_Hpic":
                srcstr = Str_dirMana + "/configuration/system/selectuserpic.aspx?FileType=user_Hpic&controlName=" + ControlName;
				break;
			case "rulePram":
                srcstr = Str_dirMana + "/configuration/system/selectrulePram.aspx?FileType=rulePram&controlName=" + ControlName;
				break;
			case "rulesmallPramo":
                srcstr = Str_dirMana + "/configuration/system/selectrulePram.aspx?FileType=rulesmallPramo&controlName=" + ControlName;
				break;
			case "rulesmallPram":
                srcstr = Str_dirMana + "/configuration/system/selectrulePram.aspx?FileType=rulesmallPram&controlName=" + ControlName;
				break;
			case "discuss_file":
                srcstr = Str_dirMana + "/configuration/system/selectuserdiscuss.aspx?FileType=discuss_file&controlName=" + ControlName;
				break;
			case "discuss_pic":
                srcstr = Str_dirMana + "/configuration/system/selectuserdiscuss.aspx?FileType=discuss_pic&controlName=" + ControlName;
				break;
			case "newsLink":
				srcstr = Str_dirMana + "/configuration/system/selectnewsLink.aspx?controlName=" + ControlName;
				break;
			case "style":
				srcstr = Str_dirMana + "/configuration/system/selectLabelStyle.aspx?controlName=" + ControlName;
				break;
			case "Channel":
				srcstr = Str_dirMana + "/configuration/system/selectChannel.aspx?controlName=" + ControlName;
				break;
			case "Source":
                srcstr = Str_dirMana + "/configuration/system/SelectSource.aspx?type=Source&controlName=" + ControlName;
				break;
			case "Author":
                srcstr = Str_dirMana + "/configuration/system/SelectSource.aspx?type=Author&controlName=" + ControlName;
				break;
			case "Tag":
                srcstr = Str_dirMana + "/configuration/system/SelectSource.aspx?type=Tag&controlName=" + ControlName;
				break;
			case "xml":
				srcstr = Str_dirMana + "/configuration/system/xml.aspx?controlName=" + ControlName;
				break;
            case "jsmodel":
                srcstr = Str_dirMana + "/configuration/system/createLabelList.aspx?controlName=" + ControlName;
                break;
            case "List":
                srcstr = Str_dirMana + "createLabelLists.aspx?controlName=" + ControlName;
                break;
            case "simpleList":
                srcstr = Str_dirMana + "createLabel_simpleList.aspx?controlName=" + ControlName;
                break;
            case "Ultimate":
                srcstr = Str_dirMana + "/configuration/system/createLabelUltimate.aspx?controlName=" + ControlName;
                break;
            case "Routine":
                srcstr = Str_dirMana + "/configuration/system/createLabelRoutine.aspx?controlName=" + ControlName;
                break;
            case "Browse":
                srcstr = Str_dirMana + "/configuration/system/createLabel_Browse.aspx?controlName=" + ControlName;
                break;
            case "Member":
                srcstr = Str_dirMana + "createLabelMember.aspx?controlName=" + ControlName;
                break;
            case "Other":
                srcstr = Str_dirMana + "createLabelOther.aspx?controlName=" + ControlName;
                break;
            case "adList":
                srcstr = Str_dirMana + "createLabel_adList.aspx?controlName=" + ControlName;
                break;
            case "API":
                srcstr = Str_dirMana + "createLabel_API.aspx?controlName=" + ControlName;
                break;
            case "PageID":
                srcstr = Str_dirMana + "/configuration/system/selectPagestyle.aspx?controlName=" + ControlName;
                break;
            case "Label1":
                srcstr = Str_dirMana + "/configuration/system/LabelList.aspx?sys=1&controlName=" + ControlName;
                break;
            case "Labelm":
                srcstr = Str_dirMana + "/configuration/system/LabelListm.aspx?controlName=" + ControlName;
                break;
            case "Label":
                srcstr = Str_dirMana + "/configuration/system/LabelList.aspx?controlName=" + ControlName;
                break;
            case "freeLabel":
                srcstr = Str_dirMana + "/configuration/system/freeLabelList.aspx?controlName=" + ControlName;
                break;
            case "ChannelLabel":
                srcstr = Str_dirMana + "../Channel/ChannelLabelList.aspx?controlName=" + ControlName;
                break;
            case "sNews":
                srcstr = Str_dirMana + "../../configuration/system/ShowNews.aspx?controlName=" + ControlName;
                break;
            case "ClassInfo":
                srcstr = Str_dirMana + "/configuration/system/createLabelClass.aspx?controlName=" + ControlName;
                break;
            case "SpecialInfo":
                srcstr = Str_dirMana + "/configuration/system/createLabelSpecial.aspx?controlName=" + ControlName;
                break;
            case "Form":
                srcstr = Str_dirMana + "createLabelForm.aspx?controlName=" + ControlName;
                break;
            case "newpublish":
                srcstr = Str_dirMana + "/configuration/system/newpublish.aspx";
                break;
			default:
				break;
		}
		liststr += "<iframe src=\"" + srcstr + "\" frameborder=\"0\" id=\"select_main\"  scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\"" + sh + "\" />";
		return liststr;
	}
}
