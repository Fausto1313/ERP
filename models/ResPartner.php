<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_partner".
 *
 * @property int $id TRIAL
 * @property string|null $name TRIAL
 * @property int|null $company_id TRIAL
 * @property string|null $create_date TRIAL
 * @property string|null $display_name TRIAL
 * @property string|null $date TRIAL
 * @property int|null $title TRIAL
 * @property int|null $parent_id TRIAL
 * @property string|null $ref TRIAL
 * @property string|null $lang TRIAL
 * @property string|null $tz TRIAL
 * @property int|null $user_id TRIAL
 * @property string|null $vat TRIAL
 * @property string|null $website TRIAL
 * @property string|null $comment TRIAL
 * @property float|null $credit_limit TRIAL
 * @property int|null $active TRIAL
 * @property int|null $employee TRIAL
 * @property string|null $function TRIAL
 * @property string|null $type TRIAL
 * @property string|null $street TRIAL
 * @property string|null $street2 TRIAL
 * @property string|null $zip TRIAL
 * @property string|null $city TRIAL
 * @property int|null $state_id TRIAL
 * @property int|null $country_id TRIAL
 * @property float|null $partner_latitude TRIAL
 * @property float|null $partner_longitude TRIAL
 * @property string|null $email TRIAL
 * @property string|null $phone TRIAL
 * @property string|null $mobile TRIAL
 * @property int|null $is_company TRIAL
 * @property int|null $industry_id TRIAL
 * @property int|null $color TRIAL
 * @property int|null $partner_share TRIAL
 * @property int|null $commercial_partner_id TRIAL
 * @property string|null $commercial_company_name TRIAL
 * @property string|null $company_name TRIAL
 * @property int|null $create_uid TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $message_main_attachment_id TRIAL
 * @property string|null $email_normalized TRIAL
 * @property int|null $message_bounce TRIAL
 * @property string|null $signup_token TRIAL
 * @property string|null $signup_type TRIAL
 * @property string|null $signup_expiration TRIAL
 * @property int|null $partner_gid TRIAL
 * @property string|null $additional_info TRIAL
 * @property string|null $phone_sanitized TRIAL
 * @property int|null $website_id TRIAL
 * @property int|null $is_published TRIAL
 * @property string|null $calendar_last_notif_ack TRIAL
 * @property int|null $team_id TRIAL
 * @property string|null $picking_warn TRIAL
 * @property string|null $picking_warn_msg TRIAL
 * @property float|null $debit_limit TRIAL
 * @property string|null $last_time_entries_checked TRIAL
 * @property string|null $invoice_warn TRIAL
 * @property string|null $invoice_warn_msg TRIAL
 * @property int|null $supplier_rank TRIAL
 * @property int|null $customer_rank TRIAL
 * @property string|null $sale_warn TRIAL
 * @property string|null $sale_warn_msg TRIAL
 * @property string|null $purchase_warn TRIAL
 * @property string|null $purchase_warn_msg TRIAL
 * @property string|null $website_meta_title TRIAL
 * @property string|null $website_meta_description TRIAL
 * @property string|null $website_meta_keywords TRIAL
 * @property string|null $website_meta_og_img TRIAL
 * @property string|null $website_description TRIAL
 * @property string|null $website_short_description TRIAL
 * @property int|null $customer TRIAL
 * @property string|null $trial496 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property CrmLead2opportunityPartner[] $crmLead2opportunityPartners
 * @property CrmLead2opportunityPartnerMass[] $crmLead2opportunityPartnerMasses
 * @property ResCompany[] $resCompanies
 * @property ResPartner $commercialPartner
 * @property ResPartner[] $resPartners
 * @property ResCompany $company
 * @property ResCountry $country
 * @property ResUsers $createU
 * @property IrAttachment $messageMainAttachment
 * @property ResPartner $parent
 * @property ResPartner[] $resPartners0
 * @property ResCountryState $state
 * @property CrmTeam $team
 * @property ResPartnerTitle $title0
 * @property ResUsers $user
 * @property ResUsers $writeU
 * @property ResPartnerBank[] $resPartnerBanks
 * @property ResUsers[] $resUsers
 * @property SaleOrder[] $saleOrders
 * @property SaleOrder[] $saleOrders0
 * @property SaleOrder[] $saleOrders1
 * @property SaleOrderLine[] $saleOrderLines
 * @property WebsiteVisitor[] $websiteVisitors
 * @property WebsiteVisitor $websiteVisitor
 */
class ResPartner extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_partner';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name', 'display_name', 'ref', 'lang', 'tz', 'vat', 'website', 'comment', 'function', 'type', 'street', 'street2', 'zip', 'city', 'email', 'phone', 'mobile', 'commercial_company_name', 'company_name', 'email_normalized', 'signup_token', 'signup_type', 'additional_info', 'phone_sanitized', 'picking_warn', 'picking_warn_msg', 'invoice_warn', 'invoice_warn_msg', 'sale_warn', 'sale_warn_msg', 'purchase_warn', 'purchase_warn_msg', 'website_meta_title', 'website_meta_description', 'website_meta_keywords', 'website_meta_og_img', 'website_description', 'website_short_description'], 'string'],
            [['company_id', 'title', 'parent_id', 'user_id', 'active', 'employee', 'state_id', 'country_id', 'is_company', 'industry_id', 'color', 'partner_share', 'commercial_partner_id', 'create_uid', 'write_uid', 'message_main_attachment_id', 'message_bounce', 'partner_gid', 'website_id', 'is_published', 'team_id', 'supplier_rank', 'customer_rank', 'customer'], 'integer'],
            [['create_date', 'date', 'write_date', 'signup_expiration', 'calendar_last_notif_ack', 'last_time_entries_checked'], 'safe'],
            [['credit_limit', 'partner_latitude', 'partner_longitude', 'debit_limit'], 'number'],
            [['trial496'], 'string', 'max' => 1],
            [['commercial_partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['commercial_partner_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['parent_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['parent_id' => 'id']],
            [['state_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountryState::className(), 'targetAttribute' => ['state_id' => 'id']],
            [['team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['team_id' => 'id']],
            [['title'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartnerTitle::className(), 'targetAttribute' => ['title' => 'id']],
            [['user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['user_id' => 'id']],
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
            'name' => 'Name',
            'company_id' => 'Company ID',
            'create_date' => 'Create Date',
            'display_name' => 'Display Name',
            'date' => 'Date',
            'title' => 'Title',
            'parent_id' => 'Parent ID',
            'ref' => 'Ref',
            'lang' => 'Lang',
            'tz' => 'Tz',
            'user_id' => 'User ID',
            'vat' => 'Vat',
            'website' => 'Website',
            'comment' => 'Comment',
            'credit_limit' => 'Credit Limit',
            'active' => 'Active',
            'employee' => 'Employee',
            'function' => 'Function',
            'type' => 'Type',
            'street' => 'Street',
            'street2' => 'Street2',
            'zip' => 'Zip',
            'city' => 'City',
            'state_id' => 'State ID',
            'country_id' => 'Country ID',
            'partner_latitude' => 'Partner Latitude',
            'partner_longitude' => 'Partner Longitude',
            'email' => 'Email',
            'phone' => 'Phone',
            'mobile' => 'Mobile',
            'is_company' => 'Is Company',
            'industry_id' => 'Industry ID',
            'color' => 'Color',
            'partner_share' => 'Partner Share',
            'commercial_partner_id' => 'Commercial Partner ID',
            'commercial_company_name' => 'Commercial Company Name',
            'company_name' => 'Company Name',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'email_normalized' => 'Email Normalized',
            'message_bounce' => 'Message Bounce',
            'signup_token' => 'Signup Token',
            'signup_type' => 'Signup Type',
            'signup_expiration' => 'Signup Expiration',
            'partner_gid' => 'Partner Gid',
            'additional_info' => 'Additional Info',
            'phone_sanitized' => 'Phone Sanitized',
            'website_id' => 'Website ID',
            'is_published' => 'Is Published',
            'calendar_last_notif_ack' => 'Calendar Last Notif Ack',
            'team_id' => 'Team ID',
            'picking_warn' => 'Picking Warn',
            'picking_warn_msg' => 'Picking Warn Msg',
            'debit_limit' => 'Debit Limit',
            'last_time_entries_checked' => 'Last Time Entries Checked',
            'invoice_warn' => 'Invoice Warn',
            'invoice_warn_msg' => 'Invoice Warn Msg',
            'supplier_rank' => 'Supplier Rank',
            'customer_rank' => 'Customer Rank',
            'sale_warn' => 'Sale Warn',
            'sale_warn_msg' => 'Sale Warn Msg',
            'purchase_warn' => 'Purchase Warn',
            'purchase_warn_msg' => 'Purchase Warn Msg',
            'website_meta_title' => 'Website Meta Title',
            'website_meta_description' => 'Website Meta Description',
            'website_meta_keywords' => 'Website Meta Keywords',
            'website_meta_og_img' => 'Website Meta Og Img',
            'website_description' => 'Website Description',
            'website_short_description' => 'Website Short Description',
            'customer' => 'Customer',
            'trial496' => 'Trial496',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartners]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerQuery
     */
    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[CrmLead2opportunityPartnerMasses]].
     *
     * @return \yii\db\ActiveQuery|CrmLead2opportunityPartnerMassQuery
     */
    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[ResCompanies]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getResCompanies()
    {
        return $this->hasMany(ResCompany::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[CommercialPartner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getCommercialPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'commercial_partner_id']);
    }

    /**
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['commercial_partner_id' => 'id']);
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
     * Gets query for [[Country]].
     *
     * @return \yii\db\ActiveQuery|ResCountryQuery
     */
    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
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
     * Gets query for [[MessageMainAttachment]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    /**
     * Gets query for [[Parent]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getParent()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'parent_id']);
    }

    /**
     * Gets query for [[ResPartners0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners0()
    {
        return $this->hasMany(ResPartner::className(), ['parent_id' => 'id']);
    }

    /**
     * Gets query for [[State]].
     *
     * @return \yii\db\ActiveQuery|ResCountryStateQuery
     */
    public function getState()
    {
        return $this->hasOne(ResCountryState::className(), ['id' => 'state_id']);
    }

    /**
     * Gets query for [[Team]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
    }

    /**
     * Gets query for [[Title0]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerTitleQuery
     */
    public function getTitle0()
    {
        return $this->hasOne(ResPartnerTitle::className(), ['id' => 'title']);
    }

    /**
     * Gets query for [[User]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
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
     * Gets query for [[ResPartnerBanks]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerBankQuery
     */
    public function getResPartnerBanks()
    {
        return $this->hasMany(ResPartnerBank::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[ResUsers]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders0]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders0()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_invoice_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders1]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders1()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_shipping_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['order_partner_id' => 'id']);
    }

    /**
     * Gets query for [[WebsiteVisitors]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['livechat_operator_id' => 'id']);
    }

    /**
     * Gets query for [[WebsiteVisitor]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitor()
    {
        return $this->hasOne(WebsiteVisitor::className(), ['partner_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResPartnerQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResPartnerQuery(get_called_class());
    }
}
