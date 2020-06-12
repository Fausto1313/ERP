<?php

namespace app\models;

use Yii;

class CrmLead extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'crm_lead';
    }

    public function rules()
    {
        return [
            [['email_cc', 'email_normalized', 'name', 'email_from', 'website', 'description', 'contact_name', 'partner_name', 'type', 'priority', 'referred', 'phone_state', 'email_state', 'street', 'street2', 'zip', 'active', 'country_name', 'team_name', 'company_name', 'city', 'phone', 'mobile', 'function'], 'string'],
            [['message_main_attachment_id', 'message_bounce', 'campaign_id', 'source_id', 'medium_id', 'partner_id', 'team_id', 'stage_id', 'user_id', 'color', 'state_id', 'country_id', 'lang_id', 'title', 'company_id', 'lost_reason', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'type'], 'required'],
            [['date_action_last', 'date_closed', 'date_open', 'date_last_stage_update', 'date_conversion', 'date_deadline', 'create_date', 'write_date'], 'safe'],
            [['day_open', 'day_close', 'probability', 'automated_probability', 'planned_revenue', 'expected_revenue'], 'number'],
            [['trial242'], 'string', 'max' => 1],
            [['campaign_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmCampaign::className(), 'targetAttribute' => ['campaign_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['lang_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResLang::className(), 'targetAttribute' => ['lang_id' => 'id']],
            [['lost_reason'], 'exist', 'skipOnError' => true, 'targetClass' => CrmLostReason::className(), 'targetAttribute' => ['lost_reason' => 'id']],
            [['medium_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmMedium::className(), 'targetAttribute' => ['medium_id' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['source_id'], 'exist', 'skipOnError' => true, 'targetClass' => UtmSource::className(), 'targetAttribute' => ['source_id' => 'id']],
            [['stage_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmStage::className(), 'targetAttribute' => ['stage_id' => 'id']],
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
            'email_cc' => 'Email Cc',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'message_bounce' => 'Message Bounce',
            'email_normalized' => 'Email',
            'campaign_id' => 'Campaign ID',
            'source_id' => 'Source ID',
            'medium_id' => 'Medium ID',
            'name' => 'Nombre de Oportunidad',
            'partner_id' => 'Cliente',
            'active' => 'Estatus',
            'date_action_last' => 'Date Action Last',
            'email_from' => 'Email From',
            'website' => 'Website',
            'team_id' => 'Equipo de Ventas',
            'team_name' => 'Equipo de Ventas',
            'description' => 'Descripcion',
            'contact_name' => 'Cliente',
            'partner_name' => 'Cliente',
            'type' => 'Tipo',
            'priority' => 'Prioridad',
            'date_closed' => 'Date Closed',
            'stage_id' => 'Stage ID',
            'user_id' => 'Email Usuario asignado',
            'referred' => 'Referred',
            'date_open' => 'Fecha  abierta de oportunidad',
            'day_open' => 'Dia abierta de oportunidad',
            'day_close' => 'Day Close',
            'date_last_stage_update' => 'Date Last Stage Update',
            'date_conversion' => 'Date Conversion',
            'probability' => 'Probabilidad',
            'automated_probability' => 'Automated Probability',
            'phone_state' => 'Phone State',
            'email_state' => 'Email State',
            'planned_revenue' => 'Ingreso Estimado',
            'expected_revenue' => 'Expected Revenue',
            'date_deadline' => 'Date Deadline',
            'color' => 'Color',
            'street' => 'Calle',
            'street2' => 'Calle 2',
            'zip' => 'Código Postal',
            'city' => 'Ciudad',
            'state_id' => 'State ID',
            'country_id' => 'Pais',
            'country_name' => 'Pais',
            'lang_id' => 'Lang ID',
            'phone' => 'Telefono',
            'mobile' => 'Celular',
            'function' => 'Funcion',
            'title' => 'Title',
            'company_id' => 'Compañia',
            'company_name' => 'Compañia',
            'lost_reason' => 'Lost Reason',
            'create_uid' => 'Usuario',
            'create_date' => 'Fecha de Creacion',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial242' => 'Trial242',
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

    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['name' => 'country_name']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getLang()
    {
        return $this->hasOne(ResLang::className(), ['id' => 'lang_id']);
    }

    public function getLostReason()
    {
        return $this->hasOne(CrmLostReason::className(), ['id' => 'lost_reason']);
    }

    public function getMedium()
    {
        return $this->hasOne(UtmMedium::className(), ['id' => 'medium_id']);
    }

    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['name' => 'partner_name']);
    }

    public function getSource()
    {
        return $this->hasOne(UtmSource::className(), ['id' => 'source_id']);
    }

    public function getStage()
    {
        return $this->hasOne(CrmStage::className(), ['id' => 'stage_id']);
    }

    public function getState()
    {
        return $this->hasOne(ResCountryState::className(), ['id' => 'state_id']);
    }

    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['name' => 'team_name']);
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

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['opportunity_id' => 'id']);
    }

    public static function find()
    {
        return new CrmLeadQuery(get_called_class());
    }
}
