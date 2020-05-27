<?php

namespace app\models;

use Yii;
class ResPartnerBank extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_partner_bank';
    }

    public function rules()
    {
        return [
            [['acc_number', 'partner_id'], 'required'],
            [['acc_number', 'sanitized_acc_number', 'acc_holder_name', 'l10n_mx_edi_clabe'], 'string'],
            [['partner_id', 'bank_id', 'sequence', 'currency_id', 'company_id', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial503'], 'string', 'max' => 1],
            [['sanitized_acc_number`(255),`company_id'], 'unique'],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'acc_number' => 'Acc Number',
            'sanitized_acc_number' => 'Sanitized Acc Number',
            'acc_holder_name' => 'Acc Holder Name',
            'partner_id' => 'Partner ID',
            'bank_id' => 'Bank ID',
            'sequence' => 'Sequence',
            'currency_id' => 'Currency ID',
            'company_id' => 'Company ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'l10n_mx_edi_clabe' => 'L10n Mx Edi Clabe',
            'trial503' => 'Trial503',
        ];
    }

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new ResPartnerBankQuery(get_called_class());
    }
}
