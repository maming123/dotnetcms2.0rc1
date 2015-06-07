<?xml version="1.0"?>
<xsl:template xmlns:xsl="http://www.w3.org/TR/WD-xsl">
	<HTML>
		<HEAD>
			<TITLE>
				<xsl:value-of select="document/webSite" />
			</TITLE>
			<style type="text/css">
				body {TEXT-ALIGN: center;}
				a:link { text-decoration: none;color: blue}
				a:active { text-decoration:blink}
				a:hover { text-decoration:underline;color: red}
				a:visited { text-decoration: none;color: green}
			</style>
		</HEAD>
		<BOBY>
			<xsl:for-each select="document/item">
				<DIV style="width:600px; text-align:left; background:#F0F8FB;">
					<div style="font-size:14px; font-weight:bold; height:20px;">
						<xsl:value-of select="title"/>
					</div>
					<div style="float:left; font-size: 14px; line-height:150%;">
						<xsl:value-of select="text"/>
					</div>
					<div style="font-size:16px;">
						<xsl:element name="A">
							<xsl:attribute name="href">
								<xsl:value-of select="link" />
							</xsl:attribute>
							<xsl:attribute name="target">_blank</xsl:attribute>
							<xsl:value-of select="link" />
						</xsl:element>
					</div>
					<div style="font-size:12px;">
						<xsl:value-of select="pubDate"/>
					</div>
					<DIV style="height:10px; background:#FFFFFF">

					</DIV>
				</DIV>
			</xsl:for-each>
		</BOBY>
	</HTML>
</xsl:template>