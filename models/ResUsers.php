<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_users".
 *
 * @property int $id TRIAL
 * @property int|null $active TRIAL
 * @property string $login TRIAL
 * @property string|null $password TRIAL
 * @property int $company_id TRIAL
 * @property int $partner_id TRIAL
 * @property string|null $create_date TRIAL
 * @property string|null $signature TRIAL
 * @property int|null $action_id TRIAL
 * @property int|null $share TRIAL
 * @property int|null $create_uid TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $alias_id TRIAL
 * @property string $notification_type TRIAL
 * @property string|null $out_of_office_message TRIAL
 * @property string $odoobot_state TRIAL
 * @property int|null $website_id TRIAL
 * @property int|null $sale_team_id TRIAL
 * @property int|null $target_sales_won TRIAL
 * @property int|null $target_sales_done TRIAL
 * @property int|null $target_sales_invoiced TRIAL
 * @property int|null $karma TRIAL
 * @property int|null $rank_id TRIAL
 * @property int|null $next_rank_id TRIAL
 * @property string|null $livechat_username TRIAL
 * @property string|null $trial532 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property CrmLead[] $crmLeads0
 * @property CrmLead[] $crmLeads1
 * @property CrmLead2opportunityPartner[] $crmLead2opportunityPartners
 * @property CrmLead2opportunityPartner[] $crmLead2opportunityPartners0
 * @property CrmLead2opportunityPartner[] $crmLead2opportunityPartners1
 * @property CrmLead2opportunityPartnerMass[] $crmLead2opportunityPartnerMasses
 * @property CrmLead2opportunityPartnerMass[] $crmLead2opportunityPartnerMasses0
 * @property CrmLead2opportunityPartnerMass[] $crmLead2opportunityPartnerMasses1
 * @property CrmLeadTag[] $crmLeadTags
 * @property CrmLeadTag[] $crmLeadTags0
 * @property CrmLostReason[] $crmLostReasons
 * @property CrmLostReason[] $crmLostReasons0
 * @property CrmStage[] $crmStages
 * @property CrmStage[] $crmStages0
 * @property CrmTeam[] $crmTeams
 * @property CrmTeam[] $crmTeams0
 * @property CrmTeam[] $crmTeams1
 * @property IrAttachment[] $irAttachments
 * @property IrAttachment[] $irAttachments0
 * @property MailAlias[] $mailAliases
 * @property MailAlias[] $mailAliases0
 * @property MailAlias[] $mailAliases1
 * @property ProductCategory[] $productCategories
 * @property ProductCategory[] $productCategories0
 * @property ProductProduct[] $productProducts
 * @property ProductProduct[] $productProducts0
 * @property ProductTemplateAttributeExclusion[] $productTemplateAttributeExclusions
 * @property ProductTemplateAttributeExclusion[] $productTemplateAttributeExclusions0
 * @property ProductTemplateAttributeValue[] $productTemplateAttributeValues
 * @property ProductTemplateAttributeValue[] $productTemplateAttributeValues0
 * @property ResCompany[] $resCompanies
 * @property ResCompany[] $resCompanies0
 * @property ResCountry[] $resCountries
 * @property ResCountry[] $resCountries0
 * @property ResCountryGroup[] $resCountryGroups
 * @property ResCountryGroup[] $resCountryGroups0
 * @property ResCountryState[] $resCountryStates
 * @property ResCountryState[] $resCountryStates0
 * @property ResLang[] $resLangs
 * @property ResLang[] $resLangs0
 * @property ResPartner[] $resPartners
 * @property ResPartner[] $resPartners0
 * @property ResPartner[] $resPartners1
 * @property ResPartnerBank[] $resPartnerBanks
 * @property ResPartnerBank[] $resPartnerBanks0
 * @property ResPartnerCategory[] $resPartnerCategories
 * @property ResPartnerCategory[] $resPartnerCategories0
 * @property ResPartnerTitle[] $resPartnerTitles
 * @property ResPartnerTitle[] $resPartnerTitles0
 * @property MailAlias $alias
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property ResUsers[] $resUsers
 * @property ResPartner $partner
 * @property CrmTeam $saleTeam
 * @property ResUsers $writeU
 * @property ResUsers[] $resUsers0
 * @property SaleOrder[] $saleOrders
 * @property SaleOrder[] $saleOrders0
 * @property SaleOrder[] $saleOrders1
 * @property SaleOrderLine[] $saleOrderLines
 * @property SaleOrderLine[] $saleOrderLines0
 * @property SaleOrderLine[] $saleOrderLines1
 * @property UtmCampaign[] $utmCampaigns
 * @property UtmCampaign[] $utmCampaigns0
 * @property UtmCampaign[] $utmCampaigns1
 * @property UtmMedium[] $utmMedia
 * @property UtmMedium[] $utmMedia0
 * @property UtmSource[] $utmSources
 * @property UtmSource[] $utmSources0
 * @property WebsiteVisitor[] $websiteVisitors
 * @property WebsiteVisitor[] $websiteVisitors0
 */
class ResUsers extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_users';
    }

    /**
     * {@inheritdoc}
     */
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

    /**
     * {@inheritdoc}
     */
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

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLeads0]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads0()
    {
        return $this->hasMany(CrmLead::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLeads1]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads1()
    {
        return $this->hasMany(CrmLead::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartners]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerQuery
     */
    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartners0]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerQuery
     */
    public function getCrmLead2opportunityPartners0()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartners1]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerQuery
     */
    public function getCrmLead2opportunityPartners1()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartnerMasses]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerMassQuery
     */
    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartnerMasses0]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerMassQuery
     */
    public function getCrmLead2opportunityPartnerMasses0()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartnerMasses1]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerMassQuery
     */
    public function getCrmLead2opportunityPartnerMasses1()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLeadTags]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadTagQuery
     */
    public function getCrmLeadTags()
    {
        return $this->hasMany(CrmLeadTag::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLeadTags0]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadTagQuery
     */
    public function getCrmLeadTags0()
    {
        return $this->hasMany(CrmLeadTag::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLostReasons]].
     *
     * @return \yii\db\ActiveQuery|CrmLostReasonQuery
     */
    public function getCrmLostReasons()
    {
        return $this->hasMany(CrmLostReason::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmLostReasons0]].
     *
     * @return \yii\db\ActiveQuery|CrmLostReasonQuery
     */
    public function getCrmLostReasons0()
    {
        return $this->hasMany(CrmLostReason::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmStages]].
     *
     * @return \yii\db\ActiveQuery|CrmStageQuery
     */
    public function getCrmStages()
    {
        return $this->hasMany(CrmStage::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmStages0]].
     *
     * @return \yii\db\ActiveQuery|CrmStageQuery
     */
    public function getCrmStages0()
    {
        return $this->hasMany(CrmStage::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmTeams]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[CrmTeams0]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams0()
    {
        return $this->hasMany(CrmTeam::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[CrmTeams1]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams1()
    {
        return $this->hasMany(CrmTeam::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[IrAttachments]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getIrAttachments()
    {
        return $this->hasMany(IrAttachment::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[IrAttachments0]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getIrAttachments0()
    {
        return $this->hasMany(IrAttachment::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[MailAliases]].
     *
     * @return \yii\db\ActiveQuery|MailAliasQuery
     */
    public function getMailAliases()
    {
        return $this->hasMany(MailAlias::className(), ['alias_user_id' => 'id']);
    }

    /**
     * Gets query for [[MailAliases0]].
     *
     * @return \yii\db\ActiveQuery|MailAliasQuery
     */
    public function getMailAliases0()
    {
        return $this->hasMany(MailAlias::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[MailAliases1]].
     *
     * @return \yii\db\ActiveQuery|MailAliasQuery
     */
    public function getMailAliases1()
    {
        return $this->hasMany(MailAlias::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductCategories]].
     *
     * @return \yii\db\ActiveQuery|ProductCategoryQuery
     */
    public function getProductCategories()
    {
        return $this->hasMany(ProductCategory::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductCategories0]].
     *
     * @return \yii\db\ActiveQuery|ProductCategoryQuery
     */
    public function getProductCategories0()
    {
        return $this->hasMany(ProductCategory::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductProducts]].
     *
     * @return \yii\db\ActiveQuery|ProductProductQuery
     */
    public function getProductProducts()
    {
        return $this->hasMany(ProductProduct::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductProducts0]].
     *
     * @return \yii\db\ActiveQuery|ProductProductQuery
     */
    public function getProductProducts0()
    {
        return $this->hasMany(ProductProduct::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductTemplateAttributeExclusions]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeExclusionQuery
     */
    public function getProductTemplateAttributeExclusions()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductTemplateAttributeExclusions0]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeExclusionQuery
     */
    public function getProductTemplateAttributeExclusions0()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductTemplateAttributeValues]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeValueQuery
     */
    public function getProductTemplateAttributeValues()
    {
        return $this->hasMany(ProductTemplateAttributeValue::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ProductTemplateAttributeValues0]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeValueQuery
     */
    public function getProductTemplateAttributeValues0()
    {
        return $this->hasMany(ProductTemplateAttributeValue::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCompanies]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getResCompanies()
    {
        return $this->hasMany(ResCompany::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCompanies0]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getResCompanies0()
    {
        return $this->hasMany(ResCompany::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountries]].
     *
     * @return \yii\db\ActiveQuery|ResCountryQuery
     */
    public function getResCountries()
    {
        return $this->hasMany(ResCountry::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountries0]].
     *
     * @return \yii\db\ActiveQuery|ResCountryQuery
     */
    public function getResCountries0()
    {
        return $this->hasMany(ResCountry::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountryGroups]].
     *
     * @return \yii\db\ActiveQuery|ResCountryGroupQuery
     */
    public function getResCountryGroups()
    {
        return $this->hasMany(ResCountryGroup::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountryGroups0]].
     *
     * @return \yii\db\ActiveQuery|ResCountryGroupQuery
     */
    public function getResCountryGroups0()
    {
        return $this->hasMany(ResCountryGroup::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountryStates]].
     *
     * @return \yii\db\ActiveQuery|ResCountryStateQuery
     */
    public function getResCountryStates()
    {
        return $this->hasMany(ResCountryState::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResCountryStates0]].
     *
     * @return \yii\db\ActiveQuery|ResCountryStateQuery
     */
    public function getResCountryStates0()
    {
        return $this->hasMany(ResCountryState::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResLangs]].
     *
     * @return \yii\db\ActiveQuery|ResLangQuery
     */
    public function getResLangs()
    {
        return $this->hasMany(ResLang::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResLangs0]].
     *
     * @return \yii\db\ActiveQuery|ResLangQuery
     */
    public function getResLangs0()
    {
        return $this->hasMany(ResLang::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartners0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners0()
    {
        return $this->hasMany(ResPartner::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[ResPartners1]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners1()
    {
        return $this->hasMany(ResPartner::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerBanks]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerBankQuery
     */
    public function getResPartnerBanks()
    {
        return $this->hasMany(ResPartnerBank::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerBanks0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerBankQuery
     */
    public function getResPartnerBanks0()
    {
        return $this->hasMany(ResPartnerBank::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerCategories]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerCategoryQuery
     */
    public function getResPartnerCategories()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerCategories0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerCategoryQuery
     */
    public function getResPartnerCategories0()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerTitles]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerTitleQuery
     */
    public function getResPartnerTitles()
    {
        return $this->hasMany(ResPartnerTitle::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerTitles0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerTitleQuery
     */
    public function getResPartnerTitles0()
    {
        return $this->hasMany(ResPartnerTitle::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[Alias]].
     *
     * @return \yii\db\ActiveQuery|MailAliasQuery
     */
    public function getAlias()
    {
        return $this->hasOne(MailAlias::className(), ['id' => 'alias_id']);
    }

    /**
     * Gets query for [[Company]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[ResUsers]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[Partner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    /**
     * Gets query for [[SaleTeam]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getSaleTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'sale_team_id']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[ResUsers0]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers0()
    {
        return $this->hasMany(ResUsers::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders0]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders0()
    {
        return $this->hasMany(SaleOrder::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders1]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders1()
    {
        return $this->hasMany(SaleOrder::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[SaleOrderLines0]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines0()
    {
        return $this->hasMany(SaleOrderLine::className(), ['salesman_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrderLines1]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines1()
    {
        return $this->hasMany(SaleOrderLine::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmCampaigns]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getUtmCampaigns()
    {
        return $this->hasMany(UtmCampaign::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmCampaigns0]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getUtmCampaigns0()
    {
        return $this->hasMany(UtmCampaign::className(), ['user_id' => 'id']);
    }

    /**
     * Gets query for [[UtmCampaigns1]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getUtmCampaigns1()
    {
        return $this->hasMany(UtmCampaign::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmMedia]].
     *
     * @return \yii\db\ActiveQuery|UtmMediumQuery
     */
    public function getUtmMedia()
    {
        return $this->hasMany(UtmMedium::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmMedia0]].
     *
     * @return \yii\db\ActiveQuery|UtmMediumQuery
     */
    public function getUtmMedia0()
    {
        return $this->hasMany(UtmMedium::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmSources]].
     *
     * @return \yii\db\ActiveQuery|UtmSourceQuery
     */
    public function getUtmSources()
    {
        return $this->hasMany(UtmSource::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[UtmSources0]].
     *
     * @return \yii\db\ActiveQuery|UtmSourceQuery
     */
    public function getUtmSources0()
    {
        return $this->hasMany(UtmSource::className(), ['write_uid' => 'id']);
    }

    /**
     * Gets query for [[WebsiteVisitors]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['create_uid' => 'id']);
    }

    /**
     * Gets query for [[WebsiteVisitors0]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitors0()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['write_uid' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResUsersQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResUsersQuery(get_called_class());
    }
}
