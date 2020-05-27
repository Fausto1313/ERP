<?php

namespace app\models;

use Yii;

class IrAttachment extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'ir_attachment';
    }

    public function rules()
    {
        return [
            [['name', 'type'], 'required'],
            [['name', 'description', 'res_model', 'res_field', 'type', 'access_token', 'db_datas', 'store_fname', 'mimetype', 'index_content', 'key'], 'string'],
            [['res_id', 'company_id', 'public', 'file_size', 'create_uid', 'write_uid', 'website_id', 'theme_template_id'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['url'], 'string', 'max' => 1024],
            [['checksum'], 'string', 'max' => 40],
            [['trial313'], 'string', 'max' => 1],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'description' => 'Description',
            'res_model' => 'Res Model',
            'res_field' => 'Res Field',
            'res_id' => 'Res ID',
            'company_id' => 'Company ID',
            'type' => 'Type',
            'url' => 'Url',
            'public' => 'Public',
            'access_token' => 'Access Token',
            'db_datas' => 'Db Datas',
            'store_fname' => 'Store Fname',
            'file_size' => 'File Size',
            'checksum' => 'Checksum',
            'mimetype' => 'Mimetype',
            'index_content' => 'Index Content',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'key' => 'Key',
            'website_id' => 'Website ID',
            'theme_template_id' => 'Theme Template ID',
            'trial313' => 'Trial313',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['message_main_attachment_id' => 'id']);
    }

    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['message_main_attachment_id' => 'id']);
    }

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getProductProducts()
    {
        return $this->hasMany(ProductProduct::className(), ['message_main_attachment_id' => 'id']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['message_main_attachment_id' => 'id']);
    }

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['message_main_attachment_id' => 'id']);
    }

    public static function find()
    {
        return new IrAttachmentQuery(get_called_class());
    }
}
