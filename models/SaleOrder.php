<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "sale_order".
 *
 * @property int $id TRIAL
 * @property int|null $campaign_id TRIAL
 * @property int|null $source_id TRIAL
 * @property int|null $medium_id TRIAL
 * @property int|null $message_main_attachment_id TRIAL
 * @property string|null $access_token TRIAL
 * @property string $name TRIAL
 * @property string|null $origin TRIAL
 * @property string|null $client_order_ref TRIAL
 * @property string|null $reference TRIAL
 * @property string|null $state TRIAL
 * @property string $date_order TRIAL
 * @property string|null $validity_date TRIAL
 * @property int|null $require_signature TRIAL
 * @property int|null $require_payment TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $user_id TRIAL
 * @property int $partner_id TRIAL
 * @property int $partner_invoice_id TRIAL
 * @property int $partner_shipping_id TRIAL
 * @property int $pricelist_id TRIAL
 * @property int|null $analytic_account_id TRIAL
 * @property string|null $invoice_status TRIAL
 * @property string|null $note TRIAL
 * @property float|null $amount_untaxed TRIAL
 * @property float|null $amount_tax TRIAL
 * @property float|null $amount_total TRIAL
 * @property float|null $currency_rate TRIAL
 * @property int|null $payment_term_id TRIAL
 * @property int|null $fiscal_position_id TRIAL
 * @property int $company_id TRIAL
 * @property int|null $team_id TRIAL
 * @property string|null $signed_by TRIAL
 * @property string|null $signed_on TRIAL
 * @property string|null $commitment_date TRIAL
 * @property int|null $create_uid TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $sale_order_template_id TRIAL
 * @property int|null $incoterm TRIAL
 * @property string $picking_policy TRIAL
 * @property int $warehouse_id TRIAL
 * @property int|null $procurement_group_id TRIAL
 * @property string|null $effective_date TRIAL
 * @property int|null $opportunity_id TRIAL
 * @property int|null $cart_recovery_email_sent TRIAL
 * @property int|null $website_id TRIAL
 * @property string|null $warning_stock TRIAL
 * @property string|null $trial539 TRIAL
 *
 * @property UtmCampaign $campaign
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property UtmMedium $medium
 * @property IrAttachment $messageMainAttachment
 * @property CrmLead $opportunity
 * @property ResPartner $partner
 * @property ResPartner $partnerInvoice
 * @property ResPartner $partnerShipping
 * @property UtmSource $source
 * @property CrmTeam $team
 * @property ResUsers $user
 * @property ResUsers $writeU
 * @property SaleOrderLine[] $saleOrderLines
 */
class SaleOrder extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'sale_order';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['campaign_id', 'source_id', 'medium_id', 'message_main_attachment_id', 'require_signature', 'require_payment', 'user_id', 'partner_id', 'partner_invoice_id', 'partner_shipping_id', 'pricelist_id', 'analytic_account_id', 'payment_term_id', 'fiscal_position_id', 'company_id', 'team_id', 'create_uid', 'write_uid', 'sale_order_template_id', 'incoterm', 'warehouse_id', 'procurement_group_id', 'opportunity_id', 'cart_recovery_email_sent', 'website_id'], 'integer'],
            [['access_token', 'name', 'origin', 'client_order_ref', 'reference', 'state', 'invoice_status', 'note', 'signed_by', 'picking_policy', 'warning_stock'], 'string'],
            [['name', 'date_order', 'partner_id', 'partner_invoice_id', 'partner_shipping_id', 'pricelist_id', 'company_id', 'picking_policy', 'warehouse_id'], 'required'],
            [['date_order', 'validity_date', 'create_date', 'signed_on', 'commitment_date', 'write_date', 'effective_date'], 'safe'],
            [['amount_untaxed', 'amount_tax', 'amount_total', 'currency_rate'], 'number'],
            [['trial539'], 'string', 'max' => 1],
            [['campaign_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmCampaign::className(), 'targetAttribute' => ['campaign_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['medium_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmMedium::className(), 'targetAttribute' => ['medium_id' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['opportunity_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmLead::className(), 'targetAttribute' => ['opportunity_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['partner_invoice_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_invoice_id' => 'id']],
            [['partner_shipping_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_shipping_id' => 'id']],
            [['source_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmSource::className(), 'targetAttribute' => ['source_id' => 'id']],
            [['team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['team_id' => 'id']],
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
            'campaign_id' => 'Campaign ID',
            'source_id' => 'Source ID',
            'medium_id' => 'Medium ID',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'access_token' => 'Access Token',
            'name' => 'Name',
            'origin' => 'Origin',
            'client_order_ref' => 'Client Order Ref',
            'reference' => 'Reference',
            'state' => 'State',
            'date_order' => 'Date Order',
            'validity_date' => 'Validity Date',
            'require_signature' => 'Require Signature',
            'require_payment' => 'Require Payment',
            'create_date' => 'Create Date',
            'user_id' => 'User ID',
            'partner_id' => 'Partner ID',
            'partner_invoice_id' => 'Partner Invoice ID',
            'partner_shipping_id' => 'Partner Shipping ID',
            'pricelist_id' => 'Pricelist ID',
            'analytic_account_id' => 'Analytic Account ID',
            'invoice_status' => 'Invoice Status',
            'note' => 'Note',
            'amount_untaxed' => 'Amount Untaxed',
            'amount_tax' => 'Amount Tax',
            'amount_total' => 'Amount Total',
            'currency_rate' => 'Currency Rate',
            'payment_term_id' => 'Payment Term ID',
            'fiscal_position_id' => 'Fiscal Position ID',
            'company_id' => 'Company ID',
            'team_id' => 'Team ID',
            'signed_by' => 'Signed By',
            'signed_on' => 'Signed On',
            'commitment_date' => 'Commitment Date',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'sale_order_template_id' => 'Sale Order Template ID',
            'incoterm' => 'Incoterm',
            'picking_policy' => 'Picking Policy',
            'warehouse_id' => 'Warehouse ID',
            'procurement_group_id' => 'Procurement Group ID',
            'effective_date' => 'Effective Date',
            'opportunity_id' => 'Opportunity ID',
            'cart_recovery_email_sent' => 'Cart Recovery Email Sent',
            'website_id' => 'Website ID',
            'warning_stock' => 'Warning Stock',
            'trial539' => 'Trial539',
        ];
    }

    /**
     * Gets query for [[Campaign]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getCampaign()
    {
        return $this->hasOne(UtmCampaign::className(), ['id' => 'campaign_id']);
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
     * Gets query for [[Medium]].
     *
     * @return \yii\db\ActiveQuery|UtmMediumQuery
     */
    public function getMedium()
    {
        return $this->hasOne(UtmMedium::className(), ['id' => 'medium_id']);
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
     * Gets query for [[Opportunity]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getOpportunity()
    {
        return $this->hasOne(CrmLead::className(), ['id' => 'opportunity_id']);
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
     * Gets query for [[PartnerInvoice]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartnerInvoice()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_invoice_id']);
    }

    /**
     * Gets query for [[PartnerShipping]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartnerShipping()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_shipping_id']);
    }

    /**
     * Gets query for [[Source]].
     *
     * @return \yii\db\ActiveQuery|UtmSourceQuery
     */
    public function getSource()
    {
        return $this->hasOne(UtmSource::className(), ['id' => 'source_id']);
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
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['order_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return SaleOrderQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new SaleOrderQuery(get_called_class());
    }
}
