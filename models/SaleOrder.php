<?php

namespace app\models;

use Yii;
class SaleOrder extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'sale_order';
    }

    public function rules()
    {
        return [
            [['campaign_id', 'source_id', 'medium_id', 'message_main_attachment_id', 'require_signature', 'require_payment', 'user_id', 'partner_id', 'partner_invoice_id', 'partner_shipping_id', 'pricelist_id', 'analytic_account_id', 'payment_term_id', 'fiscal_position_id', 'company_id', 'team_id', 'create_uid', 'write_uid', 'sale_order_template_id', 'incoterm', 'warehouse_id', 'procurement_group_id', 'opportunity_id', 'cart_recovery_email_sent', 'website_id'], 'integer'],
            [['access_token', 'name', 'origin', 'client_order_ref', 'reference', 'state', 'invoice_status', 'note', 'signed_by', 'picking_policy', 'warning_stock', 'partner_name', 'partner_invoice_name', 'partner_shipping_name', 'company_name', 'team_name'], 'string'],
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
            'id' => 'ID ',
            'campaign_id' => 'Campaign ID',
            'source_id' => 'Source ID',
            'medium_id' => 'Medium ID',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'access_token' => 'Access Token',
            'name' => 'Nombre del presupuesto',
            'origin' => 'Origen',
            'client_order_ref' => 'Client Order Ref',
            'reference' => 'Reference',
            'state' => 'Estatus',
            'date_order' => 'Fecha de Orden',
            'validity_date' => 'Validity Date',
            'require_signature' => 'Require Signature',
            'require_payment' => 'Require Payment',
            'create_date' => 'Fecha  de  creacion',
            'user_id' => 'Email de Usuario asignado',
            'partner_id' => 'Cliente',
            'partner_name' => 'Cliente',
            'partner_invoice_id' => 'Socio de factura',
            'partner_invoice_name' => 'Socio de factura',
            'partner_shipping_id' => 'Socio de envio',
            'partner_shipping_name' => 'Socio de envio',
            'pricelist_id' => 'Lista de precios',
            'analytic_account_id' => 'Analytic Account ID',
            'invoice_status' => 'Invoice Status',
            'note' => 'Nota',
            'amount_untaxed' => 'Amount Untaxed',
            'amount_tax' => 'Amount Tax',
            'amount_total' => 'Amount Total',
            'currency_rate' => 'Currency Rate',
            'payment_term_id' => 'Payment Term ID',
            'fiscal_position_id' => 'Fiscal Position ID',
            'company_id' => 'Compañia',
            'company_name' => 'Compañia',
            'team_id' => 'Equipo de Ventas',
            'team_name' => 'Equipo de Ventas',
            'signed_by' => 'Signed By',
            'signed_on' => 'Signed On',
            'commitment_date' => 'Commitment Date',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'sale_order_template_id' => 'Sale Order Template ID',
            'incoterm' => 'Incoterm',
            'picking_policy' => 'Politica',
            'warehouse_id' => 'Almacén',
            'procurement_group_id' => 'Procurement Group ID',
            'effective_date' => 'Effective Date',
            'opportunity_id' => 'Opportunity ID',
            'cart_recovery_email_sent' => 'Cart Recovery Email Sent',
            'website_id' => 'Website ID',
            'warning_stock' => 'Warning Stock',
            'trial539' => 'Trial539',
        ];
    }

    public function getCampaign()
    {
        return $this->hasOne(UtmCampaign::className(), ['id' => 'campaign_id']);
    }
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['name' => 'company_name']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getMedium()
    {
        return $this->hasOne(UtmMedium::className(), ['id' => 'medium_id']);
    }

    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    public function getOpportunity()
    {
        return $this->hasOne(CrmLead::className(), ['id' => 'opportunity_id']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['name' => 'partner_name']);
    }

    public function getPartnerInvoice()
    {
        return $this->hasOne(ResPartner::className(), ['name' => 'partner_invoice_name']);
    }

    public function getPartnerShipping()
    {
        return $this->hasOne(ResPartner::className(), ['name' => 'partner_shipping_name']);
    }

    public function getSource()
    {
        return $this->hasOne(UtmSource::className(), ['id' => 'source_id']);
    }

    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['name' => 'team_name']);
    }
    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
    }
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['order_id' => 'id']);
    }
    public static function find()
    {
        return new SaleOrderQuery(get_called_class());
    }
}
