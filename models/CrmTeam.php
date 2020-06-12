<?php

namespace app\models;

use Yii;

class CrmTeam extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'crm_team';
    }

    public function rules()
    {
        return [
            [['message_main_attachment_id', 'sequence', 'company_id', 'user_id', 'color', 'create_uid', 'write_uid', 'use_leads', 'use_opportunities', 'alias_id', 'use_quotations', 'invoiced_target'], 'integer'],
            [['name', 'alias_id'], 'required'],
            [['name', 'company_name', 'active'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial304'], 'string', 'max' => 1],
            [['alias_id'], 'exist', 'skipOnError' => true, 'targetClass' => MailAlias::className(), 'targetAttribute' => ['alias_id' => 'id']],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['user_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'name' => 'Nombre de Equipo de Venta',
            'sequence' => 'Sequence',
            'active' => 'Estatus',
            'company_id' => 'Id Compañia',
            'company_name' => 'Compañia',
            'user_id' => 'Usuario',
            'color' => 'Color',
            'create_uid' => 'Email de usuario asignado',
            'create_date' => 'Fecha de Creacion',
            'write_uid' => 'Id Usuario',
            'write_date' => 'Write Date',
            'use_leads' => 'Use Leads',
            'use_opportunities' => 'Estatus de Oportunidades',
            'alias_id' => 'Alias',
            'use_quotations' => 'Use Quotations',
            'invoiced_target' => 'Invoiced Target',
            'trial304' => 'Trial304',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['team_id' => 'id']);
    }

    public function getCrmLead2opportunityPartners()
    {
        return $this->hasMany(CrmLead2opportunityPartner::className(), ['team_id' => 'id']);
    }

    public function getCrmLead2opportunityPartnerMasses()
    {
        return $this->hasMany(CrmLead2opportunityPartnerMass::className(), ['team_id' => 'id']);
    }

    public function getCrmStages()
    {
        return $this->hasMany(CrmStage::className(), ['team_id' => 'id']);
    }

    
    public function getAlias()
    {
        return $this->hasOne(MailAlias::className(), ['id' => 'alias_id']);
    }

    
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['name' => 'company_name']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getMessageMainAttachment()
    {
        return $this->hasOne(IrAttachment::className(), ['id' => 'message_main_attachment_id']);
    }

    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['team_id' => 'id']);
    }

    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['sale_team_id' => 'id']);
    }

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['team_id' => 'id']);
    }

    public static function find()
    {
        return new CrmTeamQuery(get_called_class());
    }
}
