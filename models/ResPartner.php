<?php

namespace app\models;

use Yii;

class ResPartner extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_partner';
    }

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
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['partner_id' => 'id']);
    }
    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['partner_id' => 'id']);
    }

    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['partner_id' => 'id']);
    }

    public function getResCompanies()
    {
        return $this->hasMany(ResCompany::className(), ['partner_id' => 'id']);
    }

    public function getCommercialPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'commercial_partner_id']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['commercial_partner_id' => 'id']);
    }

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    public function getParent()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'parent_id']);
    }

    public function getResPartners0()
    {
        return $this->hasMany(ResPartner::className(), ['parent_id' => 'id']);
    }

    public function getState()
    {
        return $this->hasOne(ResCountryState::className(), ['id' => 'state_id']);
    }

    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
    }

    public function getTitle0()
    {
        return $this->hasOne(ResPartnerTitle::className(), ['id' => 'title']);
    }

    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResPartnerBanks()
    {
        return $this->hasMany(ResPartnerBank::className(), ['partner_id' => 'id']);
    }

    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['partner_id' => 'id']);
    }

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_id' => 'id']);
    }

    public function getSaleOrders0()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_invoice_id' => 'id']);
    }

    public function getSaleOrders1()
    {
        return $this->hasMany(SaleOrder::className(), ['partner_shipping_id' => 'id']);
    }

    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['order_partner_id' => 'id']);
    }

    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['livechat_operator_id' => 'id']);
    }

    public function getWebsiteVisitor()
    {
        return $this->hasOne(WebsiteVisitor::className(), ['partner_id' => 'id']);
    }

    public static function find()
    {
        return new ResPartnerQuery(get_called_class());
    }
}
