<?php

namespace app\models;

use Yii;
class ResUsers extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_users';
    }

    public function rules()
    {
        return [
            [['active', 'company_id', 'partner_id', 'action_id', 'share', 'create_uid', 'write_uid', 'alias_id', 'website_id', 'sale_team_id', 'target_sales_won', 'target_sales_done', 'target_sales_invoiced', 'karma', 'rank_id', 'next_rank_id'], 'integer'],
            [['login', 'company_id', 'partner_id', 'notification_type', 'odoobot_state'], 'required'],
            [['login', 'password', 'signature', 'notification_type', 'out_of_office_message', 'odoobot_state', 'livechat_username'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial532'], 'string', 'max' => 1],
            [['login`(255),`website_id'], 'unique'],
            [['alias_id'], 'exist', 'skipOnError' => true, 'targetClass' => MailAlias::className(), 'targetAttribute' => ['alias_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['sale_team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['sale_team_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'active' => 'Active',
            'login' => 'Login',
            'password' => 'Password',
            'company_id' => 'Company ID',
            'partner_id' => 'Partner ID',
            'create_date' => 'Create Date',
            'signature' => 'Signature',
            'action_id' => 'Action ID',
            'share' => 'Share',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'alias_id' => 'Alias ID',
            'notification_type' => 'Notification Type',
            'out_of_office_message' => 'Out Of Office Message',
            'odoobot_state' => 'Odoobot State',
            'website_id' => 'Website ID',
            'sale_team_id' => 'Sale Team ID',
            'target_sales_won' => 'Target Sales Won',
            'target_sales_done' => 'Target Sales Done',
            'target_sales_invoiced' => 'Target Sales Invoiced',
            'karma' => 'Karma',
            'rank_id' => 'Rank ID',
            'next_rank_id' => 'Next Rank ID',
            'livechat_username' => 'Livechat Username',
            'trial532' => 'Trial532',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['create_uid' => 'id']);
    }

    public function getCrmLeads0()
    {
        return $this->hasMany(CrmLead::className(), ['user_id' => 'id']);
    }

    public function getCrmLeads1()
    {
        return $this->hasMany(CrmLead::className(), ['write_uid' => 'id']);
    }

    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['create_uid' => 'id']);
    }

    public function getCrmLead2opportunityPartners0()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['user_id' => 'id']);
    }

    public function getCrmLead2opportunityPartners1()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['write_uid' => 'id']);
    }

    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['create_uid' => 'id']);
    }

    public function getCrmLead2opportunityPartnerMasses0()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['user_id' => 'id']);
    }

    public function getCrmLead2opportunityPartnerMasses1()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['write_uid' => 'id']);
    }

    public function getCrmLeadTags()
    {
        return $this->hasMany(CrmLeadTag::className(), ['create_uid' => 'id']);
    }

    public function getCrmLeadTags0()
    {
        return $this->hasMany(CrmLeadTag::className(), ['write_uid' => 'id']);
    }

    public function getCrmLostReasons()
    {
        return $this->hasMany(CrmLostReason::className(), ['create_uid' => 'id']);
    }

    public function getCrmLostReasons0()
    {
        return $this->hasMany(CrmLostReason::className(), ['write_uid' => 'id']);
    }

    public function getCrmStages()
    {
        return $this->hasMany(CrmStage::className(), ['create_uid' => 'id']);
    }

    public function getCrmStages0()
    {
        return $this->hasMany(CrmStage::className(), ['write_uid' => 'id']);
    }

    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['create_uid' => 'id']);
    }

    public function getCrmTeams0()
    {
        return $this->hasMany(CrmTeam::className(), ['user_id' => 'id']);
    }

    public function getCrmTeams1()
    {
        return $this->hasMany(CrmTeam::className(), ['write_uid' => 'id']);
    }

    public function getIrAttachments()
    {
        return $this->hasMany(IrAttachment::className(), ['create_uid' => 'id']);
    }

    public function getIrAttachments0()
    {
        return $this->hasMany(IrAttachment::className(), ['write_uid' => 'id']);
    }

    public function getMailAliases()
    {
        return $this->hasMany(MailAlias::className(), ['alias_user_id' => 'id']);
    }


    public function getMailAliases0()
    {
        return $this->hasMany(MailAlias::className(), ['create_uid' => 'id']);
    }

    public function getMailAliases1()
    {
        return $this->hasMany(MailAlias::className(), ['write_uid' => 'id']);
    }

    public function getProductCategories()
    {
        return $this->hasMany(ProductCategory::className(), ['create_uid' => 'id']);
    }

    public function getProductCategories0()
    {
        return $this->hasMany(ProductCategory::className(), ['write_uid' => 'id']);
    }

    public function getProductProducts()
    {
        return $this->hasMany(ProductProduct::className(), ['create_uid' => 'id']);
    }

    public function getProductProducts0()
    {
        return $this->hasMany(ProductProduct::className(), ['write_uid' => 'id']);
    }

    public function getProductTemplateAttributeExclusions()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['create_uid' => 'id']);
    }

    public function getProductTemplateAttributeExclusions0()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['write_uid' => 'id']);
    }

    public function getProductTemplateAttributeValues()
    {
        return $this->hasMany(ProductTemplateAttributeValue::className(), ['create_uid' => 'id']);
    }

    public function getProductTemplateAttributeValues0()
    {
        return $this->hasMany(ProductTemplateAttributeValue::className(), ['write_uid' => 'id']);
    }

    public function getResCompanies()
    {
        return $this->hasMany(ResCompany::className(), ['create_uid' => 'id']);
    }

    public function getResCompanies0()
    {
        return $this->hasMany(ResCompany::className(), ['write_uid' => 'id']);
    }

    public function getResCountries()
    {
        return $this->hasMany(ResCountry::className(), ['create_uid' => 'id']);
    }

    public function getResCountries0()
    {
        return $this->hasMany(ResCountry::className(), ['write_uid' => 'id']);
    }

    public function getResCountryGroups()
    {
        return $this->hasMany(ResCountryGroup::className(), ['create_uid' => 'id']);
    }

    public function getResCountryGroups0()
    {
        return $this->hasMany(ResCountryGroup::className(), ['write_uid' => 'id']);
    }

    public function getResCountryStates()
    {
        return $this->hasMany(ResCountryState::className(), ['create_uid' => 'id']);
    }

    public function getResCountryStates0()
    {
        return $this->hasMany(ResCountryState::className(), ['write_uid' => 'id']);
    }

    public function getResLangs()
    {
        return $this->hasMany(ResLang::className(), ['create_uid' => 'id']);
    }

    public function getResLangs0()
    {
        return $this->hasMany(ResLang::className(), ['write_uid' => 'id']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['create_uid' => 'id']);
    }

    public function getResPartners0()
    {
        return $this->hasMany(ResPartner::className(), ['user_id' => 'id']);
    }

    public function getResPartners1()
    {
        return $this->hasMany(ResPartner::className(), ['write_uid' => 'id']);
    }

    public function getResPartnerBanks()
    {
        return $this->hasMany(ResPartnerBank::className(), ['create_uid' => 'id']);
    }

    public function getResPartnerBanks0()
    {
        return $this->hasMany(ResPartnerBank::className(), ['write_uid' => 'id']);
    }

    public function getResPartnerCategories()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['create_uid' => 'id']);
    }

    public function getResPartnerCategories0()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['write_uid' => 'id']);
    }

    public function getResPartnerTitles()
    {
        return $this->hasMany(ResPartnerTitle::className(), ['create_uid' => 'id']);
    }

    public function getResPartnerTitles0()
    {
        return $this->hasMany(ResPartnerTitle::className(), ['write_uid' => 'id']);
    }

    public function getAlias()
    {
        return $this->hasOne(MailAlias::className(), ['id' => 'alias_id']);
    }

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['create_uid' => 'id']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    public function getSaleTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'sale_team_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResUsers0()
    {
        return $this->hasMany(ResUsers::className(), ['write_uid' => 'id']);
    }

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['create_uid' => 'id']);
    }

    public function getSaleOrders0()
    {
        return $this->hasMany(SaleOrder::className(), ['user_id' => 'id']);
    }

    public function getSaleOrders1()
    {
        return $this->hasMany(SaleOrder::className(), ['write_uid' => 'id']);
    }

    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['create_uid' => 'id']);
    }

    public function getSaleOrderLines0()
    {
        return $this->hasMany(SaleOrderLine::className(), ['salesman_id' => 'id']);
    }

    public function getSaleOrderLines1()
    {
        return $this->hasMany(SaleOrderLine::className(), ['write_uid' => 'id']);
    }

    public function getUtmCampaigns()
    {
        return $this->hasMany(UtmCampaign::className(), ['create_uid' => 'id']);
    }

    public function getUtmCampaigns0()
    {
        return $this->hasMany(UtmCampaign::className(), ['user_id' => 'id']);
    }

    public function getUtmCampaigns1()
    {
        return $this->hasMany(UtmCampaign::className(), ['write_uid' => 'id']);
    }
    public function getUtmMedia()
    {
        return $this->hasMany(UtmMedium::className(), ['create_uid' => 'id']);
    }
    public function getUtmMedia0()
    {
        return $this->hasMany(UtmMedium::className(), ['write_uid' => 'id']);
    }
    public function getUtmSources()
    {
        return $this->hasMany(UtmSource::className(), ['create_uid' => 'id']);
    }
    public function getUtmSources0()
    {
        return $this->hasMany(UtmSource::className(), ['write_uid' => 'id']);
    }
    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['create_uid' => 'id']);
    }

    public function getWebsiteVisitors0()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['write_uid' => 'id']);
    }

    public static function find()
    {
        return new ResUsersQuery(get_called_class());
    }
}
